using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameManeger : GameManager {

    float timelimit;

    private void OnEnable()
    {
        timelimit = 60;
    }
    
	
	// Update is called once per frame
	void Update () {
       if(timelimit >= 0) timelimit -= Time.deltaTime;
        else { gameState = GameState.interval; }
	}
}
