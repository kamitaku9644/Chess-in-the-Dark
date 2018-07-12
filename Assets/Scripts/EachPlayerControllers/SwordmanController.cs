using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanController : MovableController,IMovable {

    protected override void RowMovableSS()
    {
        int i;
        bool opponentCheck;
        var parent = playerName.transform;

        //左への移動
        for (i = nowSquareRow - 1,opponentCheck = true; i >= nowSquareRow - left; i--)
        {
            if (0 <= i && i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[i], -0.5f, selectedPlayer.transform.localPosition.z), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { opponentCheck = false; } }
                if (!opponentCheck) {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), rotate);
                    selectablesquare.transform.parent = parent;
                    selectablesquare.transform.rotation = new Quaternion(0, 0, 0, 0);
                    selectablesquare.transform.localPosition = new Vector3(row[i], -0.4f, selectedPlayer.transform.localPosition.z);
                    selectableList.Add(selectablesquare);
                    selectablesquare.name = selectableSquare.name;
                }              
               
            }

        }

        //右への移動
        for (i = nowSquareRow + 1, opponentCheck = true; i <= nowSquareRow + right; i++)
        {
            if (0 <= i & i < 12)
            {
                Collider[] check = Physics.OverlapSphere(parent.transform.TransformPoint(row[i], -0.5f, selectedPlayer.transform.localPosition.z), 0.1f);
                foreach (Collider c in check) { if (c.gameObject.transform.parent != parent) { opponentCheck = false; } }
                if (!opponentCheck)
                {
                    GameObject selectablesquare = (GameObject)Instantiate(selectableSquare, new Vector3(0, 0, 0), rotate);
                    selectablesquare.transform.parent = parent;
                    selectablesquare.transform.rotation = new Quaternion(0, 0, 0, 0);
                    selectablesquare.transform.localPosition = new Vector3(row[i], -0.4f, selectedPlayer.transform.localPosition.z);
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
        GetPlayerProperty(this.gameObject, 0,1,1,1,0);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        BaseMovableSS();
    }
    public bool Movable() { if (selectableList.Count == 0) { return false; } return true; }
    public void SSinit()
    {
        foreach (GameObject ss in selectableList)
        {
            Destroy(ss);
        }
        selectableList.Clear();
    }
}
