using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SelectManager : MonoBehaviour {


    private static BoolReactiveProperty _selecting = new BoolReactiveProperty(true);
    public static bool Selecting
    {
        get { return _selecting.Value; }
        set { _selecting.Value = value; }
    }

    private void Start()
    {
        _selecting
            .Where(x => x == false)
            .Subscribe(_ =>
            {
                
                GameManager.GameState = GameState.interval;
            });
    }
}
