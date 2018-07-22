using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResignController : MonoBehaviour {

    [SerializeField] private GameObject resign;
   

    private ILoading load;
    private bool rayhit;

    private void Start()
    {
        load = resign.GetComponentInChildren<ILoading>();
        rayhit = false;
    }

    public void Resign(GameObject activeCamera)
    {
        

        Ray ray = new Ray(activeCamera.transform.position, activeCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == resign)
            {
                load.Loading();
                rayhit = true;
                if (load.LoadComp()) {
                    if(activeCamera.tag == "Player1") { ResultManager.PResult = Result.player1lose; }
                    else { ResultManager.PResult = Result.player1win; }
                    SceneManager.LoadScene("Result"); }
            }
        }
        else if (rayhit == true)
        {
            load.Loadinit();
            rayhit = false;
        }
    }
}
