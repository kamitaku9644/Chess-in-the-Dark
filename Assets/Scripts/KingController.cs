using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MoveController,IMovable {

    public new void Movable()
        {
        GetPlayerProperty(this.gameObject, 1, 1, 1, 1, 1);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        base.Movable();
        
        }

    public void SSinit() {
        foreach (GameObject ss in selectableList)
        {
            Destroy(ss);
            
        }
    }
    
    

}
