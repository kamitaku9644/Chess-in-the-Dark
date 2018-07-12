﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopController : MovableController,IMovable {
    public void MovableSS()
    {
        GetPlayerProperty(this.gameObject, 0,0,0,0,12);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        BaseMovableSS();
        this.GetComponent<BishopSearchController>().Search();
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
