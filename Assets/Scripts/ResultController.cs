using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour {


    [SerializeField] private GameObject bottum;
    [SerializeField] private GameObject Player1Camera;
    [SerializeField] private GameObject Player2Camera;

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject draw;

    private ILoading load1;
    private ILoading load2;
    private bool rayhit1;
    private bool rayhit2;

    // Use this for initialization
    void Start()
    {
        load1 = Player1Camera.GetComponentInChildren<ILoading>();
        load2 = Player2Camera.GetComponentInChildren<ILoading>();

        rayhit1 = false;
        rayhit2 = false;

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
        Ray ray1 = new Ray(Player1Camera.transform.position, Player1Camera.transform.forward);
        RaycastHit hit1;

        if (Physics.Raycast(ray1, out hit1))
        {
            if (hit1.collider.gameObject == bottum)
            {
                load1.Loading();
                rayhit1 = true;
                if (load1.LoadComp()) { SceneManager.LoadScene("Start"); }
            }
        }
        else if (rayhit1 == true)
        {
            load1.Loadinit();
            rayhit1 = false;
        }




        Ray ray2 = new Ray(Player2Camera.transform.position, Player2Camera.transform.forward);
        RaycastHit hit2;

        if (Physics.Raycast(ray2, out hit2))
        {
            if (hit2.collider.gameObject == bottum)
            {
                load2.Loading();
                rayhit2 = true;
                if (load2.LoadComp()) { SceneManager.LoadScene("Start"); }
            }
        }
        else if (rayhit2 == true)
        {
            load2.Loadinit();
            rayhit2 = false;
        }
    }
}
