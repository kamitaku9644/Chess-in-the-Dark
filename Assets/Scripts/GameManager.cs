using System.Collections;
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

   
    public GameObject selectGM;


    RayController rayController;

    

    // Use this for initialization
    void Start () {
        gameState = GameState.select;
        selectGM.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        print("GM:" +gameState);
        switch (gameState)
        {
            case GameState.select:
                selectGM.SetActive(true);
                break;
                

            case GameState.moverdy:
                moveComp = false;
                selectGM.SetActive(false);
                RayController.HittedPlayer.GetComponentInChildren<IMove>().MoveRdy(RayController.HittedSquare);
                gameState = GameState.move;
                break;

            case GameState.move:
                RayController.HittedPlayer.GetComponentInChildren<IMove>().Move();
                if (moveComp) { gameState = GameState.search; }
                break;

            case GameState.search:
                print("search");
                break;
            case GameState.interval:
                print("interval");
                break;
        }

        
	}
}
