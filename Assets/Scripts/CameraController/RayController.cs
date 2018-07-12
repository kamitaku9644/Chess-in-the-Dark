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

    

    bool rayhitted;
    GameObject hittedObj;    
    GameObject hesHittedPlayer;
    ILoading playerLoad;    
    ILoading squareLoad;

    string playerName;

    public void OnEnable()
    {
        playerName = this.tag;
        hittedObj = null;
        hittedPlayer = null;
        hittedSquare = null;

        selectState = SelectState.playerSelect;
        rayhitted = false;
    }

    public void PlayerSelect()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {


            hittedObj = hit.collider.gameObject;
            rayhitted = true;

            switch (selectState)
            {
                case SelectState.playerSelect:

                    if (hittedObj.transform.parent.tag == playerName)
                    {
                        if (hittedPlayer == null)
                        {
                            hittedPlayer = hittedObj;
                            playerLoad = hittedPlayer.GetComponentInChildren<ILoading>();
                            hittedPlayer.GetComponent<IMovable>().MovableSS();
                        }
                        else
                        {
                            if (hittedPlayer.GetComponent<IMovable>().Movable())
                            {
                                playerLoad.Loading();
                                if (playerLoad.LoadComp()) { selectState = SelectState.squareSelect; }
                            }

                        }
                    }

                    break;



                case SelectState.squareSelect:

                    //playseselect cancel
                    if (hittedObj.transform.parent.tag == playerName && hittedObj.tag == "Player")
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
                                hittedSquare.GetComponent<IDestroy>().SetDestroyer();
                                GameManager.GameState = GameState.moverdy;

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
                        hittedPlayer.GetComponent<IMovable>().SSinit();
                        hittedPlayer = null;
                        if (playerLoad != null) { playerLoad.Loadinit(); }
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
   

    public void Selectinit()
    {

        if (hittedPlayer != null)
        {
            hittedPlayer.GetComponent<IMovable>().SSinit();
            hittedPlayer = null;
            if (playerLoad != null) { playerLoad.Loadinit(); }
        }

        if (hesHittedPlayer != null)
        {
            playerLoad.Loadinit();
            hesHittedPlayer = null;
        }

        if (hittedSquare != null)
        {
            squareLoad.Loadinit();
            hittedSquare = null;
        }


        
    }


}
