using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovable : MoveController {

    //斜め移動
    protected override void Movable()
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
