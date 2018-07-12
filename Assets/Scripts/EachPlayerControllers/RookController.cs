using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookController : MovableController,IMovable {

    public void MovableSS()
    {
        GetPlayerProperty(this.gameObject, 12,12,12,12,0);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        BaseMovableSS();
        this.GetComponent<RookSearchController>().Search();
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
