using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMoveController : MoveController,IMove {

    public override void MoveRdy(GameObject hittedSquare)
    {
        base.MoveRdy(hittedSquare);
        this.GetComponent<RookSearchController>().Search(hittedSquare);
    }
}
