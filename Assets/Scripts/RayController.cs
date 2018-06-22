using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour
{

    public GameObject MainCamera;

    GameObject hittedPlayer;

    GameObject hesHittedPlayer;
    ILoading playerLoad;

    GameObject hittedSquare;
    ILoading squareLoad;

    bool playerSelected;
    bool squareSelected;

    // Use this for initialization
    void Start()
    {
        playerSelected = false;
        squareSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;


        //(state)player select
        if (!playerSelected)
        {
            

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Player1")
                {
                    if (hittedPlayer == null)
                    {
                        hittedPlayer = hit.collider.gameObject;
                        playerLoad = hittedPlayer.GetComponentInChildren<ILoading>();
                        hittedPlayer.GetComponent<IMovable>().Movable();
                    }
                    else
                    {
                        playerLoad.Loading();
                        if (playerLoad.LoadComp()) { playerSelected = true; }

                    }
                }

            }
            else if (hittedPlayer != null)
            {
                playerLoad.Loadinit();
                hittedPlayer.GetComponent<IMovable>().SSinit();
                hittedPlayer = null;
            }
            
        }
        else
        {
            //(state)square select



            if (Physics.Raycast(ray, out hit))
            {
                //player cancel
                if (hit.collider.gameObject.tag == "Player1")
                {
                    if (hesHittedPlayer == null)
                    {
                        hesHittedPlayer = hit.collider.gameObject;
                        playerLoad = hesHittedPlayer.GetComponentInChildren<ILoading>();
                    }
                    else
                    {
                        playerLoad.Loading();
                        if (playerLoad.LoadComp()) {
                            hittedPlayer.GetComponent<IMovable>().SSinit();
                            hittedPlayer = null;
                            playerSelected = false;                                                             
                        }

                    }
                }


                //square select
                if (hit.collider.gameObject.tag == "SelectableSquare")
                {
                    if (hittedSquare == null)
                    {
                        hittedSquare = hit.collider.gameObject;
                        squareLoad = hittedSquare.GetComponentInChildren<ILoading>();
                    }
                    else
                    {
                        squareLoad.Loading();
                        if (squareLoad.LoadComp()) {
                            hittedPlayer.GetComponentInChildren<IMove>().Move(hittedSquare);
                            squareSelected = true;
                        }
                    }

                }

            }
            else
            {
                if (hesHittedPlayer != null) {
                    playerLoad.Loadinit();
                    hesHittedPlayer = null;
                }
                if (hittedSquare != null) {
                    squareLoad.Loadinit();
                    hittedSquare = null;
                }
            }
        }
    }
}
