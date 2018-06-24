using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameState { start,select,move,search,interval,result}
    public GameState gameState;

    public GameObject selectGM;
    protected GameObject hittedPlayer;
    protected GameObject hittedSquare;
    public GameObject mainCamera;

    public bool moveComp;

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
                print(hittedPlayer.name);
                print(hittedSquare.name);
                moveComp = false;
                selectGM.SetActive(false);
                hittedPlayer.GetComponentInChildren<IMove>().Move(hittedSquare);
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
