﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MovableController,IMovable {

    public void MovableSS()
        {
        GetPlayerProperty(this.gameObject, 1, 1, 1, 1, 1);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        BaseMovableSS();
        
        }
    public bool Movable() { if (selectableList.Count == 0) { return false; } return true; }
    public void SSinit() {
        foreach (GameObject ss in selectableList)
        {
            Destroy(ss);
            
        }
        selectableList.Clear();
    }
    
    

}
