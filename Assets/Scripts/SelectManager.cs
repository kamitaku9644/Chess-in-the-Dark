using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class SelectManager : MonoBehaviour{


    private static BoolReactiveProperty _selecting = new BoolReactiveProperty(true);
    public static bool Selecting
    {
        get { return _selecting.Value; }
        set { _selecting.Value = value; }
    }

   

    RayController rayController;

    private void Start()
    {
        rayController = this.GetComponentInChildren<RayController>();



        this.UpdateAsObservable()
            .Where(_ => GameManager.GameState == GameState.select && Selecting == true)
            .Subscribe(_ => rayController.PlayerSelect());
            


        _selecting
            .ThrottleFirst(TimeSpan.FromSeconds(1))
            .Where(x => GameManager.GameState == GameState.select && this.gameObject.activeSelf &&  x == false)
            .Subscribe(_ =>
            {
               rayController.Selectinit();
                if (GameManager.PlayerTurn == 1)
                {
                   GameManager.PlayerTurn = 2;
                }
                else if (GameManager.PlayerTurn == 2)
                {
                    GameManager.PlayerTurn = 1;
                    
                }
                GameManager.GameState = GameState.interval;
            });
    }
}
