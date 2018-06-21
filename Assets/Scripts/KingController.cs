using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MoveController,IMovable {

    readonly QueueMovable queueMovable = new QueueMovable();
    readonly RowMovable rowMovable = new RowMovable();
    readonly DiagonalMovable diagonalMovable = new DiagonalMovable();
    
    public void Movable()
    {
        GetPlayerProperty(1, 1, 1, 1, 1);
        GetQueue(selectedPlayer.transform.localPosition.x);
        GetRow(selectedPlayer.transform.localPosition.z);

        queueMovable.Movable();
        rowMovable.Movable();
        diagonalMovable.Movable();
    }

    

}
