using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MovableController,IMovable {

    //前方に敵がいたら移動不可
    protected override void QueueMovableSS()
    {
        int i;
        bool queueCheck;
        bool opponentCheck;
        var parent = playerName.transform;


        //後方への移動
        for (i = nowSquareQueue - 1, queueCheck = true, opponentCheck = true; i >= nowSquareQueue - back; i--)
        {

            if (0 <= i && i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(selectedPlayer.transform.localPosition.x, -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { queueCheck = false; } else { opponentCheck = false; } }
                if (!queueCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), rotate);
                selectablesquare.transform.parent = parent;
                selectablesquare.transform.rotation = new Quaternion(0, 0, 0, 0);
                selectablesquare.transform.localPosition = new Vector3(selectedPlayer.transform.localPosition.x, -0.4f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;
                if (opponentCheck == false) { break; }
            }

        }

        //前方への移動
        for (i = nowSquareQueue + 1, queueCheck = true, opponentCheck = true; i <= nowSquareQueue + forward; i++)
        {
            if (0 <= i & i < 12)
            {

                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(selectedPlayer.transform.localPosition.x, -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent == parent) { queueCheck = false; } else { opponentCheck = false; } }
                if (!queueCheck | !opponentCheck) { break; }
                GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), rotate);
                selectablesquare.transform.parent = parent;
                selectablesquare.transform.rotation = new Quaternion(0, 0, 0, 0);
                selectablesquare.transform.localPosition = new Vector3(selectedPlayer.transform.localPosition.x, -0.4f, queue[i]);
                selectableList.Add(selectablesquare);
                selectablesquare.name = selectableSquare.name;

            }

        }
        layerController = gameObject.AddComponent<LayerController>();
        foreach (GameObject ss in selectableList) { layerController.SetLayer(parent.gameObject, ss); }
        Destroy(layerController);
    }

    //斜め前方に敵がいたら攻撃
    protected override void DiagonalMovableSS()
    {
        int i;
        int ii;        
        bool opponentCheck;
        var parent = playerName.transform;

        
        //左前方への移動
        for (i = nowSquareQueue + 1, ii = nowSquareRow - 1, opponentCheck = true; i <= nowSquareQueue + diagonal && ii >= nowSquareRow - diagonal; i++, ii--)
        {
            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { opponentCheck = false; } }
                if (!opponentCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), rotate);
                    selectablesquare.transform.parent = parent;
                    selectablesquare.transform.rotation = new Quaternion(0, 0, 0, 0);
                    selectablesquare.transform.localPosition = new Vector3(row[ii], -0.4f, queue[i]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
        }
        //右前方への移動
        for (i = nowSquareQueue + 1, ii = nowSquareRow + 1,opponentCheck = true; i <= nowSquareQueue + diagonal && ii <= nowSquareRow + diagonal; i++, ii++)
        {
            if (0 <= i & i < 12 & 0 <= ii & ii < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[ii], -0.5f, queue[i]), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { opponentCheck = false; } }
                if (!opponentCheck) {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), rotate);
                    selectablesquare.transform.parent = parent;
                    selectablesquare.transform.rotation = new Quaternion(0, 0, 0, 0);
                    selectablesquare.transform.localPosition = new Vector3(row[ii], -0.4f, queue[i]);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }
            }
        }
        layerController = gameObject.AddComponent<LayerController>();
        foreach (GameObject ss in selectableList) { layerController.SetLayer(parent.gameObject, ss); }
        Destroy(layerController);
    }




    public void MovableSS()
    {
       
        GetPlayerProperty(this.gameObject, 0,1,0,0,1);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        BaseMovableSS();
        
    }
    public bool Movable() { if(selectableList.Count == 0) { return false; }return true; }

    public void SSinit()
    {
        foreach (GameObject ss in selectableList)
        {
            Destroy(ss);
        }
        selectableList.Clear();
    }
}
