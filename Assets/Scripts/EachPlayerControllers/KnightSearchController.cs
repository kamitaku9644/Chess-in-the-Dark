using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSearchController : SearchableController {

    public void Search()
    {
        GetPlayerProperty(this.gameObject, 0, 0, 0, 0, 0, 1);
        GetQueue(selectedPlayer.transform.localPosition.z);
        GetRow(selectedPlayer.transform.localPosition.x);

        KnightSearchable();

    }
}
