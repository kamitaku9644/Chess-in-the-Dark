using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour {


    [SerializeField] private GameObject bottum;
    [SerializeField] private GameObject MainCamera;

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject draw;

    private ILoading load;
    private bool rayhit;

    // Use this for initialization
    void Start()
    {
        load = MainCamera.GetComponentInChildren<ILoading>();
        rayhit = false;

        switch (ResultManager.PResult)
        {
            case Result.player1win:
                win.layer = 9;
                lose.layer = 10;
                draw.layer = 0;
                break;

            case Result.player1lose:
                win.layer = 10;
                lose.layer = 9;
                draw.layer = 0;
                break;

            case Result.draw:
                win.layer = 0;
                lose.layer = 0;
                draw.layer = 5;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == bottum)
            {
                load.Loading();
                rayhit = true;
                if (load.LoadComp()) { SceneManager.LoadScene("Start"); }
            }
        }
        else if (rayhit == true)
        {
            load.Loadinit();
            rayhit = false;
        }
    }
}
