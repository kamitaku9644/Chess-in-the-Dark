using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SelectGameManager {

    public float limitTime;

    public bool TimeCount()
    {
        limitTime -= Time.deltaTime;
        if(limitTime >= 0) { return true; }
        return false;
    }
	
}
