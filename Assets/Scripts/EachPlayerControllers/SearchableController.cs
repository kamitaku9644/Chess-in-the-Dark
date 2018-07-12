using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableController : MonoBehaviour {
    //player property
    protected GameObject playerName;

    protected GameObject selectedPlayer;
    protected int back;
    protected int forward;
    protected int right;
    protected int left;
    protected int diagonal;
    protected int searchcount;


    protected int nowSquareQueue;
    protected int nowSquareRow;

    protected Quaternion rotate = new Quaternion(-90, 0, 0, 0);

    public List<GameObject> selectableList = new List<GameObject>();


    protected readonly float[] queue = new float[12];
    protected readonly float[] row = new float[12];

    protected LayerController layerController;

    protected void GetPlayerProperty(GameObject g, int b, int f, int r, int l, int d, int c)
    {
        playerName = g.transform.parent.gameObject;
        selectedPlayer = g;
        back = b;
        forward = f;
        right = r;
        left = l;
        diagonal = d;
        searchcount = c;
    }


    //列取得
    protected void GetQueue(float playerpositionz)
    {
        float a;
        int b;

        for (a = -5.5f, b = 0; -6 < a & a < 6; a++, b++)
        {
            queue[b] = a;
            if (a - 0.5f < playerpositionz && playerpositionz <= a + 0.5f) { nowSquareQueue = b; }
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
            if (c - 0.5f < playerpositionx && playerpositionx <= c + 0.5f) { nowSquareRow = d; }
        }
    }

    public void BaseSearchable()
    {
        QueueSearchable();
        RowSearchable();
        DiagonalSearchable();

    }



    //列移動可能範囲
    virtual protected void QueueSearchable()
    {
        int i;      
        var parent = playerName.transform;


        //後方への移動
        for (i = nowSquareQueue - 1; i >= nowSquareQueue - back; i--)
        {

            if (0 <= i && i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(selectedPlayer.transform.localPosition.x, -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }

            }

        }

        //前方への移動
        for (i = nowSquareQueue + 1; i <= nowSquareQueue + forward; i++)
        {
            if (0 <= i & i < 12)
            {

                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(selectedPlayer.transform.localPosition.x, -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }

            }

        }
        
    }



    //行移動可能範囲
    virtual protected void RowSearchable()
    {
        int i;       
        var parent = playerName.transform;

        //左への移動
        for (i = nowSquareRow - 1; i >= nowSquareRow - left; i--)
        {
            if (0 <= i && i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[i], -0.5f, selectedPlayer.transform.localPosition.z), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }
            }

        }

        //右への移動
        for (i = nowSquareRow + 1; i <= nowSquareRow + right; i++)
        {
            if (0 <= i & i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[i], -0.5f, selectedPlayer.transform.localPosition.z), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }
            }

        }
        
    }

    //斜め移動可能範囲
    virtual protected void DiagonalSearchable()
    {
        int i;
        int ii;       
        var parent = playerName.transform;

        //左後方への移動
        for (i = nowSquareQueue - 1, ii = nowSquareRow - 1; i >= nowSquareQueue - diagonal && ii >= nowSquareRow - diagonal; i--, ii--)
        {

            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }
            }
        }
        //右後方への移動
        for (i = nowSquareQueue - 1, ii = nowSquareRow + 1; i >= nowSquareQueue - diagonal && ii <= nowSquareRow + diagonal; i--, ii++)
        {

            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }

            }
        }
        //左前方への移動
        for (i = nowSquareQueue + 1, ii = nowSquareRow - 1; i <= nowSquareQueue + diagonal && ii >= nowSquareRow - diagonal; i++, ii--)
        {
            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }
            }
        }
        //右前方への移動
        for (i = nowSquareQueue + 1, ii = nowSquareRow + 1; i <= nowSquareQueue + diagonal && ii <= nowSquareRow + diagonal; i++, ii++)
        {
            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.GetComponent<ISearch>().Searched(searchcount); } }
            }
        }
        
    }


    protected void KnightSearchable()
    {
        var parent = playerName.transform;
        int i = nowSquareQueue;
        int ii = nowSquareRow;

        if (0 <= i + 2 && i + 2 < 12)
        {
            if (0 <= ii + 1 && ii + 1 < 12)
            {
                
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 1], -0.5f, queue[i + 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
                
            }
            if (0 <= ii - 1 && ii - 1 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 1], -0.5f, queue[i + 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }

            }
        }
        if (0 <= i - 2 && i - 2 < 12)
        {
            if (0 <= ii + 1 && ii + 1 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 1], -0.5f, queue[i - 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
            }
            if (0 <= ii - 1 && ii - 1 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 1], -0.5f, queue[i - 2]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
            }
        }
        if (0 <= i - 1 && i - 1 < 12)
        {
            if (0 <= ii + 2 && ii + 2 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 2], -0.5f, queue[i - 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
            }
            if (0 <= ii - 2 && ii - 2 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 2], -0.5f, queue[i - 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
            }
        }
        if (0 <= i + 1 && i + 1 < 12)
        {
            if (0 <= ii + 2 && ii + 2 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii + 2], -0.5f, queue[i + 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
            }
            if (0 <= ii - 2 && ii - 2 < 12)
            {
               
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii - 2], -0.5f, queue[i + 1]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { c.gameObject.GetComponent<ISearch>().Searched(searchcount); } }
            }
        }

       
    }


}
