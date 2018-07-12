using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour {

    public void SetLayer(GameObject parent, GameObject obj)
    {

        int layerNo = parent.layer;
        obj.layer = layerNo;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            obj.transform.GetChild(i).gameObject.layer = layerNo;
　　　　　　　　
　　　　　　　　SetLayer(parent,obj.transform.GetChild(i).gameObject);

        }
        
    }
}
