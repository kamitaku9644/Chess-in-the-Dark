using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameManeger : GameManager {
    public GameObject rayCtl;


    float timelimit;
    protected GameManager gameManager;

    private void OnEnable()
    {
        timelimit = 60;
        
    }
    
	
	// Update is called once per frame
	void Update () {
        rayCtl.SetActive(true);
       if(timelimit >= 0) timelimit -= Time.deltaTime;
        
	}
    private void LateUpdate()
    {
        if(timelimit < 0) {
            gameManager.PGameState = GameState.interval;
            this.gameObject.SetActive(false);
        }
    }
}
