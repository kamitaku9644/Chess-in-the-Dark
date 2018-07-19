using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerChecker : MonoBehaviour {

    GameManager gameManager;
    public static BoolReactiveProperty PlayerChecked
    {
        get;
        private set;
    }

    private List<GameObject> _exsistPlayer1 = new List<GameObject>();
    public List<GameObject> ExsistPlayer1
    {
        get { return _exsistPlayer1; }        
    }
    private List<GameObject> _exsistPlayer2 = new List<GameObject>();
    public List<GameObject> ExsistPlayer2
    {
        get { return _exsistPlayer2; }        
    }
    GameObject king;


    private void Start()
    {
        gameManager = this.GetComponent<GameManager>();
        PlayerChecked = new BoolReactiveProperty(false);

        GameManager.PPlayerTurn
            .Subscribe(_ => PlayerCheck())
            .AddTo(this);
    }



    public void PlayerCheck()
    {

        //現存コマの取得
        PlayerChecked.Value = false;
        _exsistPlayer1.Clear();
        _exsistPlayer2.Clear();

        foreach (GameObject p in gameManager.Player1.transform)
        {
            if (p.tag == "Player") { _exsistPlayer1.Add(p); }
        }
        foreach (GameObject p in gameManager.Player2.transform)
        {
            if (p.tag == "Player") { _exsistPlayer2.Add(p); }
        }

        PlayerChecked.Value = true;

    }
}
