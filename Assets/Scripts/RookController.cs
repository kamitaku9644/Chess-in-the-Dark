using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookController : MoveController,IMovable {

    public new void Movable()
    {
        GetPlayerProperty(this.gameObject, 12,12,12,12,0);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        base.Movable();
    }
}
