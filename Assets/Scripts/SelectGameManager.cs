using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameManager : MonoBehaviour {
    public GameObject MainCamera;

    protected bool playerSelected;

    RayController rayController = new RayController();
    TimeManager timeManager = new TimeManager();

    // Use this for initialization
    void Start () {
        playerSelected = false;
        timeManager.limitTime = 60;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeManager.TimeCount())
        {
            if (rayController.RayHittd())
            {
                if (!playerSelected) { rayController.PlayerSelect(); }
                else
                {
                    rayController.PlayerSelectCancel();
                    rayController.SquareSelect();
                }
            }
        }
        else
        {
            //call move
            print("call move");
        }
	}
}
