using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ExsistPlayerPresenter : MonoBehaviour {

    [SerializeField] private GameObject exsistplayer1UI;
    [SerializeField] private GameObject exsistplayer2UI;

    PlayerChecker playerChecker;

    private void Start()
    {
        playerChecker = this.GetComponent<PlayerChecker>();

        PlayerChecker.PlayerChecked
            .Where(x => x == true)
            .Subscribe(_ => 
            {
                ExsistPlayerPresent(exsistplayer1UI, playerChecker.ExsistPlayer1);
                ExsistPlayerPresent(exsistplayer2UI, playerChecker.ExsistPlayer2);
            })
            .AddTo(this);
    }



    private void ExsistPlayerPresent(GameObject ui,List<Transform> list)
    {
        Text t = ui.GetComponentInChildren<Text>();

        int kingCount = 0;
        int queenCount = 0;
        int bishopCount = 0;
        int rookCount = 0;
        int knightCount = 0;
        int swordmanCount = 0;
        int archerCount = 0;

        foreach(Transform p in list)
        {
            if (p.name == "King") kingCount++;
            if (p.name == "Queen") queenCount++;
            if (p.name == "Bishop") bishopCount++;
            if (p.name == "Rook") rookCount++;
            if (p.name == "Knight") knightCount++;
            if (p.name == "Swordman") swordmanCount++;
            if(p.name == "Archer")  archerCount++; 
        }



        string king = "King: " + kingCount;
        string queen = "Queen: " + queenCount;
        string bishop = "Bishop : " + bishopCount;
        string rook = "Rook : " + rookCount;
        string knight = "Knight : " + knightCount;
        string swordman = "Swordman : " + swordmanCount;
        string archer = "Archer : " + archerCount;

        t.text = (string)ui.name + "\n" + "\n" + king + "\n" + queen + "\n" + bishop + "\n" + rook + "\n" + knight + "\n" + swordman + "\n" + archer;
    }
}
