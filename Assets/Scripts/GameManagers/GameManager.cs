﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class GameManager : MonoBehaviour {

    private static ReactiveProperty<GameState> _gameState = new ReactiveProperty<GameState>(GameState.initialize);
    public static GameState GameState
    {
        get { return _gameState.Value; }
        set { _gameState.Value = value; }
    }

    public static ReactiveProperty<GameState> PGameState
    {
        get { return _gameState; }
    }

    static bool moveComp;
    public static bool MoveComp
    {
        private get { return moveComp; }
        set { moveComp = value; }
    }

    private static IntReactiveProperty _playerTurn;

    public static IntReactiveProperty PPlayerTurn
    {
        get { return _playerTurn; }
    }

    public static int PlayerTurn{
        get { return _playerTurn.Value; }
        set { _playerTurn.Value = value; }
    }

    [SerializeField] private GameObject player1;
    public GameObject Player1
    {
        get { return player1; }
    }
    [SerializeField] private GameObject player2;
    public GameObject Player2
    {
        get { return player2; }
    }
    [SerializeField] private GameObject player1Camera;
    [SerializeField] private GameObject player2Camera;
    

    public CompositeDisposable _disposables = new CompositeDisposable();
    public CompositeDisposable Disposables
    {
        get { return _disposables; }
    }

    private GameObject activeCamera;


    TimeManager timeManager;
    InitializeController initializeController;
    ScaleManager scaleManager;
    ResignController resignController;

   
   

    // Use this for initialization
    void Start () {

        
        timeManager = this.GetComponent<TimeManager>();
        initializeController = this.GetComponent<InitializeController>();
        scaleManager = this.GetComponent<ScaleManager>();
        resignController = this.GetComponent<ResignController>();

        activeCamera = player1Camera;

        _gameState
            .Subscribe(state =>
            {
                _disposables.Clear();
                print(state);
                GameStateChanged(state);
            })
            .AddTo(this);

        _playerTurn            
            .Subscribe(turn =>
            {
                
                if(turn == 1) {
                    player1Camera.SetActive(true);
                    player2Camera.SetActive(false);

                    activeCamera = player1Camera;
                }
                else if(turn == 2) {
                    player1Camera.SetActive(false);
                    player2Camera.SetActive(true);

                    activeCamera = player2Camera;
                }
            })
            .AddTo(this);

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
                Interval();
                
                break;
        }
    }



    

    private void Initialize()
    {
        initializeController.PlayerInit(player1);
        initializeController.PlayerInit(player2);

        _playerTurn = new IntReactiveProperty(1);
        player1Camera.SetActive(true);
        GameState = GameState.select;
    }

    private void Selectrdy()
    {
        RayController.HittedPlayer.GetComponentInChildren<IMove>().Moveinit();
        
        scaleManager.SelectScale(player1,player2);
        if (PlayerTurn == 2)
        {
            PlayerTurn = 1;
        }
        else if (PlayerTurn == 1)
        {
            PlayerTurn = 2;
        }
        GameState = GameState.select;
    }


    private void Select()
    {
        timeManager.CountSet(10);

        this.LateUpdateAsObservable()
            .Where(_ => SelectManager.Selecting == true)
           .Subscribe(_ =>
           {
               timeManager.CountTime();
               resignController.Resign(activeCamera);
           })
           .AddTo(Disposables);


    }



    private void Moverdy()
    { 

        moveComp = false;
        if (PlayerTurn == 1) { player1Camera.SetActive(false); }
        else if (PlayerTurn == 2) { player2Camera.SetActive(false); }

        RayController.HittedPlayer.GetComponentInChildren<IMove>().MoveRdy(RayController.HittedSquare);

        scaleManager.MoveScale(player1, player2);

        GameState = GameState.move;
    }


    private void Move()
    {

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                RayController.HittedPlayer.GetComponentInChildren<IMove>().Move();
                if (moveComp) { GameState = GameState.selectrdy; }

            })
            .AddTo(Disposables);

        
    }

    private void Interval()
    {
        
        
        GameState = GameState.select;
    }
}
