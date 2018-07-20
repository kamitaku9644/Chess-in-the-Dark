using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultManager : MonoBehaviour {
    Result result;
    PlayerChecker playerChecker;

    private void Start()
    {
        playerChecker = this.GetComponent<PlayerChecker>();

        PlayerChecker.PlayerChecked
            .Where(x => x == true)
            .Subscribe(_ => ResultCheck())
            .AddTo(this);
    }

    private void ResultCheck()
    {
        int kingCount = 0;
        int bishopCount = 0;
        int knightCount = 0;
        GameObject king = null;

        foreach (Transform p in playerChecker.ExsistPlayer1)
        {
            if (p.name == "King")
            {
                kingCount++;
                king = p.gameObject;
            }
            if (p.name == "Bishop") { bishopCount++; }
            if (p.name == "Knight") { knightCount++; }
        }
        foreach (Transform p in playerChecker.ExsistPlayer2)
        {
            if (p.name == "King")
            {
                kingCount++;
                king = p.gameObject;
            }
            if (p.name == "Bishop") { bishopCount++; }
            if (p.name == "Knight") { knightCount++; }
        }

        //終了分岐
        if(kingCount == 2)
        {
            if (bishopCount == 1) { result = Result.draw; }
            else if (knightCount == 1) { result = Result.draw; }
        }
        else if (kingCount == 1)
        {
            if (king.transform.parent.name == "Player1") { result = Result.player1win; }
            else { result = Result.player1lose; }
        }
        
    }
}
