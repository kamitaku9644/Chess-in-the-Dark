using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookSearchController : SearchableController{

    public void Search(GameObject hittedSquare)
    {
        GetPlayerProperty(this.gameObject,hittedSquare, 0, 2, 2, 2, 2,3);
        GetQueue(hittedSquare.transform.localPosition.z);
        GetRow(hittedSquare.transform.localPosition.x);

        BaseSearchable();
        
    }

    protected override void DiagonalSearchable()
    {
        int i;
        int ii;
        var parent = playerName.transform;
               
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
}
