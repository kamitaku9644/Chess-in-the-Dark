using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopController : MovableController,IMovable {
    public new void Movable()
    {
        GetPlayerProperty(this.gameObject, 0,0,0,0,12);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        base.Movable();
    }

    public void SSinit()
    {
        foreach (GameObject ss in selectableList)
        {
            Destroy(ss);
        }
    }
}
