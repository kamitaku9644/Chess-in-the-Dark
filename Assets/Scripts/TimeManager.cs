using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    [SerializeField] private GameObject timelimitUI;
    

    private float timelimit;

    public void CountSet(float i)
    {
        timelimit = i;
        SelectManager.Selecting = true;
    }

	public void CountTime () {
        if (timelimit >= 0)
        {
            timelimit -= Time.deltaTime;
            timelimitUI.GetComponentInChildren<Text>().text = ((int)timelimit).ToString();
        }
        else
        {
            SelectManager.Selecting = false;
        }
	}
    
}
