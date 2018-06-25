using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameState { start, select, move, search, interval, result }
    GameState gameState;
    public GameState PGameState
    {
        set { gameState = value; }
    }

    bool moveComp;

    public bool MoveComp
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
        switch (gameState)
        {
            case GameState.select:
                selectGM.SetActive(true);

                break;
                

            case GameState.move:
                print(rayController.HittedPlayer.name);
                print(rayController.HittedSquare.name);
                moveComp = false;
                selectGM.SetActive(false);
                rayController.HittedPlayer.GetComponentInChildren<IMove>().Move(rayController.HittedSquare);
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
