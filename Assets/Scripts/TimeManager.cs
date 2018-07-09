using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeManager : MonoBehaviour {

    [SerializeField] private GameObject timelimitUI;
    

    private static FloatReactiveProperty _timelimit;

   

    public void CountSet(float i)
    {
        _timelimit = new FloatReactiveProperty(i);
        SelectManager.Selecting = true;
       
    }

	public void CountTime () {
        if (_timelimit.Value >= 0)
        {
            _timelimit.Value -= Time.deltaTime;
            timelimitUI.GetComponentInChildren<Text>().text = ((int)_timelimit.Value).ToString();
            
            
        }
        else if(SelectManager.Selecting == true)
        {
            SelectManager.Selecting = false;
            
        }
	}
    
   
}
