using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopController : MoveController,IMovable {
    public new void Movable()
    {
        GetPlayerProperty(this.gameObject, 0,0,0,0,12);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        base.Movable();
    }

}
