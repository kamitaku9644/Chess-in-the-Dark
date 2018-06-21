using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueMovable : MoveController {

    //列移動
    protected override void Movable()
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

}
