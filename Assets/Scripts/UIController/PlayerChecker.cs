using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerChecker : MonoBehaviour {

    
    private static BoolReactiveProperty _playerChecked = new BoolReactiveProperty(false);
    public static  BoolReactiveProperty PlayerChecked
    {
        get { return _playerChecked; }
    }

    private List<Transform> _exsistPlayer1 = new List<Transform>();
    public List<Transform> ExsistPlayer1
    {
        get { return _exsistPlayer1; }        
    }

    private List<Transform> _exsistPlayer2 = new List<Transform>();
    public List<Transform> ExsistPlayer2
    {
        get { return _exsistPlayer2; }        
    }

    GameManager gameManager;

    private void Start()
    {
        gameManager = this.GetComponent<GameManager>();

        

        GameManager.PPlayerTurn
            .Subscribe(_ => PlayerCheck())
            .AddTo(this);
    }



    public void PlayerCheck()
    {

        //現存コマの取得
        _playerChecked.Value = false;
        if (_exsistPlayer1 != null)
        {
            _exsistPlayer1.Clear();
            _exsistPlayer2.Clear();
        }


        foreach (Transform p in gameManager.Player1.transform)
        {
            if (p.tag == "Player") { _exsistPlayer1.Add(p); }
        }
        foreach (Transform p in gameManager.Player2.transform)
        {
            if (p.tag == "Player") { _exsistPlayer2.Add(p); }
        }

        _playerChecked.Value = true;

    }
}
