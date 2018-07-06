using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class SelectManager : MonoBehaviour {


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
            .Subscribe(_ => rayController.PlayerSelect());
            

        _selecting
            .Where(x => x == false)
            .Subscribe(_ => GameManager.GameState = GameState.interval);
    }
}
