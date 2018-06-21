using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovable : MoveController,IMovable {

    public  void Movable()
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
}
