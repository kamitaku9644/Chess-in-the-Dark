using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject MainCamera;

    private ILoading load;
    private bool rayhit;

	// Use this for initialization
	void Start () {
        load = MainCamera.GetComponentInChildren<ILoading>();
        rayhit = false;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject == start)
            {
                load.Loading();
                rayhit = true;
                if (load.LoadComp()) { SceneManager.LoadScene("Main"); }
            }
        }else if(rayhit == true)
        {
            load.Loadinit();
            rayhit = false;
        }
    }
}
