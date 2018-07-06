using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameManager : MonoBehaviour {

    private static ReactiveProperty<GameState> _gameState = new ReactiveProperty<GameState>(GameState.initialize);
    public static GameState GameState
    {
        get { return _gameState.Value; }
        set { _gameState.Value = value; }
    }

    static bool moveComp;

    public static bool MoveComp
    {
        private get { return moveComp; }
        set { moveComp = value; }
    }

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player1Camera;
    [SerializeField] private GameObject player2Camera;
 


    RayController rayController1;
    RayController rayController2;
    TimeManager timeManeger;
    InitializeController initializeController;
    ScaleManager scaleManager;

    // Use this for initialization
    void Start () {

        rayController1 = player1Camera.GetComponentInChildren<RayController>();
        rayController2 = player2Camera.GetComponentInChildren<RayController>();
        timeManeger = this.GetComponentInChildren<TimeManager>();
        initializeController = this.GetComponentInChildren<InitializeController>();
        scaleManager = this.GetComponentInChildren<ScaleManager>();


        _gameState
            .Subscribe(state =>
            {
                print(state);
                GameStateChanged(state);
            });
        
	}

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            
            case GameState.select:
                timeManeger.CountTime();
                if (SelectManager.Selecting)
                {
                    if (player1Camera.activeSelf) { rayController1.PlayerSelect(); }
                    if (player2Camera.activeSelf) { rayController2.PlayerSelect(); }
                }
                

                break;

            case GameState.move:
                RayController.HittedPlayer.GetComponentInChildren<IMove>().Move();

                break;

            case GameState.search:
                
                break;
            case GameState.interval:
               
                break;
        }


    }

    private void GameStateChanged(GameState state)
    {
        
        switch (state)
        {
            case GameState.initialize:

                Initialize();

                break;
            case GameState.selectrdy:
                
                break;

            case GameState.select:
                timeManeger.CountSet(30);

                break;


            case GameState.moverdy:
                Moverdy();
                break;

            case GameState.move:
                
                break;

            case GameState.search:
               
                GameState = GameState.selectrdy;
                break;
            case GameState.interval:
               
                GameState = GameState.selectrdy;
                break;
        }
    }



    

    private void Initialize()
    {
        initializeController.PlayerInit(player1);
        initializeController.PlayerInit(player2);
        GameState = GameState.select;
    }

    private void Selectrdy()
    {
        RayController.HittedPlayer.GetComponentInChildren<IMove>().Moveinit();
        if (RayController.HittedPlayer.transform.parent == player2.transform) { player1Camera.SetActive(true); }
        else if (RayController.HittedPlayer.transform.parent == player1.transform) { player2Camera.SetActive(true); }
        scaleManager.SelectScale(player1,player2);
        GameState = GameState.select;
    }

    private void Moverdy()
    {
        moveComp = false;
        


        if (RayController.HittedPlayer.transform.parent == player1.transform) { player1Camera.SetActive(false); }
        else if (RayController.HittedPlayer.transform.parent == player2.transform) { player2Camera.SetActive(false); }
        RayController.HittedPlayer.GetComponentInChildren<IMove>().MoveRdy(RayController.HittedSquare);
        scaleManager.MoveScale(player1, player2);
        GameState = GameState.move;
    }


    private void Select()
    {

    }
}
