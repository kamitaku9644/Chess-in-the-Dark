using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour
{

    public enum SelectState { playerSelect, squareSelect};
    SelectState selectState;
    
    static GameObject hittedPlayer;

    public static GameObject HittedPlayer
    {
        get { return hittedPlayer; }

    }

    static GameObject hittedSquare;

    public static GameObject HittedSquare
    {
        get { return hittedSquare; }
    }

    public GameObject mainCamera;
    bool rayhitted;
    GameObject hittedObj;



    GameObject hesHittedPlayer;
    ILoading playerLoad;


    ILoading squareLoad;

    void OnEnable()
    {

        selectState = SelectState.playerSelect;
        rayhitted = false;
    }

    void Update()
    {
        print("RC:" + GameManager.PGameState);


        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        switch (GameManager.PGameState) {

            case GameState.select:

                if (Physics.Raycast(ray, out hit))
                {


                    hittedObj = hit.collider.gameObject;
                    rayhitted = true;

                    switch (selectState)
                    {
                        case SelectState.playerSelect:

                            if (hittedObj.tag == "Player1")
                            {
                                if (hittedPlayer == null)
                                {
                                    hittedPlayer = hittedObj;
                                    playerLoad = hittedPlayer.GetComponentInChildren<ILoading>();
                                    hittedPlayer.GetComponent<IMovable>().Movable();
                                }
                                else
                                {
                                    playerLoad.Loading();
                                    if (playerLoad.LoadComp()) { selectState = SelectState.squareSelect; }

                                }
                            }

                            break;



                        case SelectState.squareSelect:

                            //playseselect cancel
                            if (hittedObj.tag == "Player1")
                            {
                                if (hesHittedPlayer == null)
                                {
                                    hesHittedPlayer = hittedObj;
                                    playerLoad = hesHittedPlayer.GetComponentInChildren<ILoading>();
                                }
                                else
                                {
                                    playerLoad.Loading();

                                    if (playerLoad.LoadComp())
                                    {
                                        hittedPlayer.GetComponent<IMovable>().SSinit();
                                        hittedPlayer = null;
                                        selectState = SelectState.playerSelect;
                                    }

                                }
                            }


                            //square select
                            if (hittedObj.tag == "SelectableSquare")
                            {
                                if (hittedSquare == null)
                                {
                                    hittedSquare = hittedObj;
                                    squareLoad = hittedSquare.GetComponentInChildren<ILoading>();
                                }
                                else
                                {
                                    squareLoad.Loading();
                                    if (squareLoad.LoadComp())
                                    {
                                        GameManager.PGameState = GameState.moverdy;

                                    }
                                }
                            }


                            break;
                    }

                }

                //initiallization
                else if (rayhitted)
                {
                    hittedObj = null;
                    rayhitted = false;


                    switch (selectState)
                    {
                        case SelectState.playerSelect:



                            if (hittedPlayer != null)
                            {
                                playerLoad.Loadinit();
                                hittedPlayer.GetComponent<IMovable>().SSinit();
                                hittedPlayer = null;
                            }

                            break;

                        case SelectState.squareSelect:

                            //playseselect cancel
                            if (hesHittedPlayer != null)
                            {
                                playerLoad.Loadinit();
                                hesHittedPlayer = null;
                            }



                            //square select
                            if (hittedSquare != null)
                            {
                                squareLoad.Loadinit();
                                hittedSquare = null;
                            }


                            break;
                    }
                }
                break;

            case GameState.moverdy:
                
                break;
    }


}






}
