using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMoveController : MoveController,IMove {

    public override void MoveRdy(GameObject hittedSquare)
    {
        base.MoveRdy(hittedSquare);
        this.GetComponent<KnightSearchController>().Search(hittedSquare);
    }
}
