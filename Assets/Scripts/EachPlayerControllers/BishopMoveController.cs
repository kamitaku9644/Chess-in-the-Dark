using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMoveController : MoveController,IMove {

    public override void MoveRdy(GameObject hittedSquare)
    {
        base.MoveRdy(hittedSquare);
        this.GetComponent<BishopSearchController>().Search(hittedSquare);
    }
}
