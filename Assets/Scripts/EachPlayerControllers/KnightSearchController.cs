using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSearchController : SearchableController {

    public void Search(GameObject hittedSquare)
    {
        GetPlayerProperty(this.gameObject, hittedSquare, 0, 0, 0, 0, 0, 1);
        GetQueue(hittedSquare.transform.localPosition.z);
        GetRow(hittedSquare.transform.localPosition.x);

        KnightSearchable();

    }
}
