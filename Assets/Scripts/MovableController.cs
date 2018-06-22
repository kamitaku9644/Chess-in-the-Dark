using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableController : MonoBehaviour {

    public GameObject selectableSquare;

    //player property
    protected GameObject playerName;

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



    protected void GetPlayerProperty(GameObject g, int b, int f, int r, int l, int d)
    {
        playerName = g.transform.parent.gameObject;
        selectedPlayer = g;
        back = b;
        forward = f;
        right = r;
        left = l;
        diagonal = d;
    }
    
    
    //列取得
    protected void GetQueue(float playerpositionz)
    {
        float a;
        int b;

        for (a = -5.5f, b = 0; -6 < a & a < 6; a++, b++)
        {
            queue[b] = a;
            if (queue[b] == playerpositionz) { nowSquareQueue = b; }
        }
    }

    //行取得
    protected void GetRow(float playerpositionx)
    {
        float c;
        int d;

        for (c = -5.5f, d = 0; -6 < c & c < 6; c++, d++)
        {
            row[d] = c;
            if (c == playerpositionx) { nowSquareRow = d; }
        }
    }

    public void Movable()
    {
        QueueMovable();
        RowMovable();
        DiagonalMovable();
    }


    protected void KnightMovable()
    {
        var parent = playerName.transform;
        int i = nowSquareQueue;
        int ii = nowSquareRow;

        if (0 <= i + 2 && i + 2 < 12)
        {
            if (0 <= ii + 1 && ii + 1 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 1], 0, queue[i + 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii + 1], 0.1f, queue[i + 2]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
            if (0 <= ii - 1 && ii - 1 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 1], 0, queue[i + 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii - 1], 0.1f, queue[i + 2]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
        }
        if (0 <= i - 2 && i - 2 < 12)
        {
            if (0 <= ii + 1 && ii + 1 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 1], 0, queue[i - 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii + 1], 0.1f, queue[i - 2]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
            if (0 <= ii - 1 && ii - 1 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 1], 0, queue[i - 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii - 1], 0.1f, queue[i - 2]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
        }
        if (0 <= i - 1 && i - 1 < 12)
        {
            if (0 <= ii + 2 && ii + 2 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 2], 0, queue[i - 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii + 2], 0.1f, queue[i - 1]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
            if (0 <= ii - 2 && ii - 2 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 2], 0, queue[i - 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii - 2], 0.1f, queue[i - 1]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
        }
        if (0 <= i + 1 && i + 1 < 12)
        {
            if (0 <= ii + 2 && ii + 2 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 2], 0, queue[i + 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii + 2], 0.1f, queue[i + 1]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
            if (0 <= ii - 2 && ii - 2 < 12)
            {
                bool knightCheck = true;
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 2], 0, queue[i + 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { knightCheck = false; } }
                if (knightCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                    selectablesquare.transform.localPosition = new Vector3(row[ii - 2], 0.1f, queue[i + 1]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
        }
    }



    //列移動可能範囲
    void QueueMovable()
    {
        int i;
        bool queueCheck;
        var parent = playerName.transform;

        //後方への移動
        for (i = nowSquareQueue - 1, queueCheck = true; i >= nowSquareQueue - back; i--)
        {

            if (0 <= i && i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(selectedPlayer.transform.localPosition.x, 0, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { queueCheck = false; } }
                if (!queueCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(selectedPlayer.transform.localPosition.x, 0.1f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }

        }

        //前方への移動
        for (i = nowSquareQueue + 1, queueCheck = true; i <= nowSquareQueue + forward; i++)
        {
            if (0 <= i & i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(selectedPlayer.transform.localPosition.x, 0, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { queueCheck = false; } }
                if (!queueCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(selectedPlayer.transform.localPosition.x, 0.1f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }

        }
    }



    //行移動可能範囲
    void RowMovable()
    {
        int i;
        bool rowCheck;
        var parent = playerName.transform;

        //左への移動
        for (i = nowSquareRow - 1, rowCheck = true; i >= nowSquareRow - left; i--)
        {
            if (0 <= i && i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[i], 0, selectedPlayer.transform.localPosition.z), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { rowCheck = false; } }
                if (!rowCheck) { break; }

                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(row[i], 0.1f, selectedPlayer.transform.localPosition.z);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }

        }

        //右への移動
        for (i = nowSquareRow + 1, rowCheck = true; i <= nowSquareRow + right; i++)
        {
            if (0 <= i & i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[i], 0, selectedPlayer.transform.localPosition.z), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { rowCheck = false; } }
                if (!rowCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(row[i], 0.1f, selectedPlayer.transform.localPosition.z);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }

        }
    }

    //斜め移動可能範囲
    void DiagonalMovable()
    {
        int i;
        int ii;
        bool diagonalCheck;
        var parent = playerName.transform;

        //左後方への移動
        for (i = nowSquareQueue - 1, ii = nowSquareRow - 1, diagonalCheck = true; i >= nowSquareQueue - diagonal && ii >= nowSquareRow - diagonal; i--, ii--)
        {

            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], 0, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { diagonalCheck = false; } }
                if (!diagonalCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(row[ii], 0.1f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }
        }
        //右後方への移動
        for (i = nowSquareQueue - 1, ii = nowSquareRow + 1, diagonalCheck = true; i >= nowSquareQueue - diagonal && ii <= nowSquareRow + diagonal; i--, ii++)
        {

            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], 0, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { diagonalCheck = false; } }
                if (!diagonalCheck) { break; }

                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(row[ii], 0.1f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }
        }
        //左前方への移動
        for (i = nowSquareQueue + 1, ii = nowSquareRow - 1, diagonalCheck = true; i <= nowSquareQueue + diagonal && ii >= nowSquareRow - diagonal; i++, ii--)
        {
            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], 0, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { diagonalCheck = false; } }
                if (!diagonalCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(row[ii], 0.1f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }
        }
        //右前方への移動
        for (i = nowSquareQueue + 1, ii = nowSquareRow + 1, diagonalCheck = true; i <= nowSquareQueue + diagonal && ii <= nowSquareRow + diagonal; i++, ii++)
        {
            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], 0, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { diagonalCheck = false; } }
                if (!diagonalCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), parent.rotation, parent);
                selectablesquare.transform.localPosition = new Vector3(row[ii], 0.1f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }
        }

    }



}







