using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : GameManager
{
    
    enum SelectState { playerSelect, squareSelect };
    SelectState selectState;
    public GameObject mainCamera;

    bool rayhitted;
    GameObject hittedObj;

    GameObject hittedPlayer;

    GameObject hesHittedPlayer;
    ILoading playerLoad;

    GameObject hittedSquare;
    ILoading squareLoad;

    void Start()
    {
        selectState = SelectState.playerSelect;
        rayhitted = false;
    }

    void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

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
                                hittedPlayer.GetComponentInChildren<IMove>().Move(hittedSquare);
                                //call move
                                print("called move");
                            }
                        }
                    }


                    break;
            }

        }

        //initiallization
        else if(rayhitted){
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

       
    }




















    /*
    public void RayHitted()
    {
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hittedObj = hit.collider.gameObject;
            
        }
        return;
    }


    public void PlayerSelect()
    {
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
                if (playerLoad.LoadComp()) { playerSelected = true; }

            }
        }
        else if (hittedPlayer != null)
        {
            playerLoad.Loadinit();
            hittedPlayer.GetComponent<IMovable>().SSinit();
            hittedPlayer = null;
        }

    }


    public void PlayerSelectCancel()
    {
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
                    playerSelected = false;
                }

            }
        }
        else
        {
            if (hesHittedPlayer != null)
            {
                playerLoad.Loadinit();
                hesHittedPlayer = null;
            }
        }
    }



    public void SquareSelect()
    {
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
                    hittedPlayer.GetComponentInChildren<IMove>().Move(hittedSquare);
                    //call move
                    print("called move");
                }
            }

        }
        else
        {
            if (hittedSquare != null)
            {
                squareLoad.Loadinit();
                hittedSquare = null;
            }
        }
    }
    */





/*
    

    // Update is called once per frame
    void Update()
    {
        


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
    }*/
}
