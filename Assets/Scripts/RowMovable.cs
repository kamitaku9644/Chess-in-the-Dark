using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMovable : MoveController {

    //行移動
    public void Movable()
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
}
