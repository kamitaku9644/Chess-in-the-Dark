using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadController: MonoBehaviour,ILoading {

    public float loadTimerate;
    
    float loadtime;
    Image loadCtl;

    public void Loading()
    {
        loadCtl = this.GetComponentInChildren<Image>();
        loadtime += Time.deltaTime * loadTimerate;
        loadCtl.fillAmount = loadtime;


    }

    public bool LoadComp()
    {
        if (loadCtl.fillAmount >= 1) {
            loadtime = 0;
            loadCtl.fillAmount = 0;
            return true;
        }
        else return false;
    }

    public void Loadinit()
    {
        if (loadtime > 0)
        {
            loadCtl.fillAmount = 0;
            loadtime = 0;
        }
    }
}
