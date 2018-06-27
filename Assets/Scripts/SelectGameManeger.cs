using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameManeger : GameManager {

    public GameObject timelimitUI;

    float timelimit;
    

    private void OnEnable()
    {
        timelimit = 60;
        
    }
    
	
	// Update is called once per frame
	void Update () {
       if(timelimit >= 0) timelimit -= Time.deltaTime;
        timelimitUI.GetComponentInChildren<Text>().text = ((int)timelimit).ToString();
	}
    private void LateUpdate()
    {
        if(timelimit < 0) {
            PGameState = GameState.interval;
            this.gameObject.SetActive(false);
        }
    }
}
