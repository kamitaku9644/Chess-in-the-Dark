using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour{

    public GameObject MainCamera;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            hit.collider.gameObject.GetComponent<IMovable>().Movable();
        }
	}
}
