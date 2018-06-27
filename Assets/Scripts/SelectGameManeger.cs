using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameManeger : GameManager {
    public GameObject rayCtl;


    float timelimit;
    GameManager gameManager;

    private void OnEnable()
    {
        timelimit = 60;
        
    }
    
	
	// Update is called once per frame
	void Update () {
       if(timelimit >= 0) timelimit -= Time.deltaTime;
        
	}
    private void LateUpdate()
    {
        if(timelimit < 0) {
            PGameState = GameState.interval;
            this.gameObject.SetActive(false);
        }
    }
}
