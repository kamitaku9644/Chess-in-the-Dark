using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

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

    private static int _playerTurn = 1;
    public static int PlayerTurn{
        get { return _playerTurn; }
    }

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player1Camera;
    [SerializeField] private GameObject player2Camera;

    private CompositeDisposable disposable = new CompositeDisposable();

    
    TimeManager timeManeger;
    InitializeController initializeController;
    ScaleManager scaleManager;

    // Use this for initialization
    void Start () {

        
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
                
                

                break;

            case GameState.move:
               

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
                Selectrdy();
                break;

            case GameState.select:
                Select();
                
                break;


            case GameState.moverdy:
                Moverdy();
                break;

            case GameState.move:
                Move(); 
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
        disposable.Clear();
        RayController.HittedPlayer.GetComponentInChildren<IMove>().Moveinit();
        
        scaleManager.SelectScale(player1,player2);
        if (PlayerTurn == 2)
        {
            _playerTurn = 1;
            player1Camera.SetActive(true);
        }
        else if (PlayerTurn == 1)
        {
            _playerTurn = 2;
            player2Camera.SetActive(true);
        }
        GameState = GameState.select;
    }

    private void Moverdy()
    {
        disposable.Clear();
        moveComp = false;
        


        if (PlayerTurn == 1) { player1Camera.SetActive(false); }
        else if (PlayerTurn == 2) { player2Camera.SetActive(false); }
        RayController.HittedPlayer.GetComponentInChildren<IMove>().MoveRdy(RayController.HittedSquare);
        scaleManager.MoveScale(player1, player2);
        GameState = GameState.move;
    }


    private void Select()
    {
        timeManeger.CountSet(30);

        this.UpdateAsObservable()
            .Subscribe(_ => timeManeger.CountTime())
            .AddTo(disposable);
        
        
        
    }

    private void Move()
    {

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                RayController.HittedPlayer.GetComponentInChildren<IMove>().Move();
                if (moveComp) { GameState = GameState.selectrdy; }

            })
            .AddTo(disposable);

        
    }
}
