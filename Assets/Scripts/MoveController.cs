using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public GameObject selectableSquare;

    //player property
    public GameObject playerName;

    protected GameObject selectedPlayer;
    protected int back;
    protected int forward;
    protected int right;
    protected int left;
    protected int diagonal;


    protected int nowSquareQueue;
    protected int nowSquareRow;



    public List<GameObject> selectableList = new List<GameObject>();

    protected readonly float[] queue = new float[12];
    protected readonly float[] row = new float[12];



    void GetPlayerProperty(int b, int f, int r, int l, int d)
    {
        selectedPlayer = this.gameObject;
        back = b;
        forward = f;
        right = r;
        left = l;
        diagonal = d;
    }
    
    
    //列取得
    void GetQueue(float playerpositionx)
    {
        float a;
        int b;

        for (a = -5.5f, b = 0; -6 < a & a < 6; a++, b++)
        {
            queue[b] = a;
            if (queue[b] == playerpositionx) { nowSquareQueue = b; }
        }
    }

    //行取得
    void GetRow(float playerpositionz)
    {
        float c;
        int d;

        for (c = -5.5f, d = 0; -6 < c & c < 6; c++, d++)
        {
            row[d] = c;
            if (c == playerpositionz) { nowSquareRow = d; }
        }
    }



    protected virtual void Movable() { }


}
