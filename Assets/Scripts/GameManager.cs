﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    static GameState gameState;
    public static GameState PGameState
    {
        get { return gameState; }
        set { gameState = value; }
    }

    static bool moveComp;

    public static bool MoveComp
    {
        private get { return moveComp; }
        set { moveComp = value; }
    }

    public GameObject player1;
    public GameObject player2;
    public GameObject player1Camera;
    public GameObject player2Camera;
    public GameObject selectGM;
    

    // Use this for initialization
    void Start () {
        gameState = GameState.initialize;
        selectGM.SetActive(false);
	}

   



    // Update is called once per frame
    void Update () {
        print("GM:" +gameState);
        switch (gameState)
        {
            case GameState.initialize:       
                gameState = GameState.select;
               
                
                break;
            case GameState.selectrdy:
                RayController.HittedPlayer.GetComponentInChildren<IMove>().Moveinit();
                print(RayController.HittedPlayer.transform.parent.name);
                if (RayController.HittedPlayer.transform.parent == player2.transform) { player1Camera.SetActive(true); }
                else if (RayController.HittedPlayer.transform.parent == player1.transform) { player2Camera.SetActive(true); }
                
                gameState = GameState.select;
                break;

            case GameState.select:
                selectGM.SetActive(true);

                break;
                

            case GameState.moverdy:
                moveComp = false;
                selectGM.SetActive(false);
                if (RayController.HittedPlayer.transform.parent == player1.transform) { player1Camera.SetActive(false); }
                else if (RayController.HittedPlayer.transform.parent == player2.transform) { player2Camera.SetActive(false); }
                RayController.HittedPlayer.GetComponentInChildren<IMove>().MoveRdy(RayController.HittedSquare);
                gameState = GameState.move;
                break;

            case GameState.move:
                RayController.HittedPlayer.GetComponentInChildren<IMove>().Move();
                if (moveComp) { gameState = GameState.search; }
                break;

            case GameState.search:
                print("search");
                gameState = GameState.selectrdy;
                break;
            case GameState.interval:
                print("interval");
                gameState = GameState.selectrdy;
                break;
        }

        
	}
    private void LateUpdate()
    {
        if(gameState == GameState.initialize) {
            this.GetComponentInChildren<InitializeController>().PlayerInit(player1);
            this.GetComponentInChildren<InitializeController>().PlayerInit(player2);
        }
    }
}
