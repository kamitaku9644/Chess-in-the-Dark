using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour {


	public void SelectScale(GameObject player1, GameObject player2)
    {
        Transform[] eachPlayer1 = player1.GetComponentsInChildren<Transform>();
        Transform[] eachPlayer2 = player2.GetComponentsInChildren<Transform>();
        foreach (Transform eachplayer in eachPlayer1)
        {
            if (eachplayer.gameObject.tag == "Player")
            {
                eachplayer.localScale = new Vector3(0.5f, 0.25f, 0.5f);
            }
        }
        foreach (Transform eachplayer in eachPlayer2)
        {
            if (eachplayer.gameObject.tag == "Player")
            {
                eachplayer.localScale = new Vector3(0.5f, 0.25f, 0.5f);
            }
        }
        
    }


    public void MoveScale(GameObject player1, GameObject player2)
    {
       Transform[] eachPlayer1 = player1.GetComponentsInChildren<Transform>();
       Transform[] eachPlayer2 = player2.GetComponentsInChildren<Transform>();
        foreach (Transform eachplayer in eachPlayer1)
        {
            if (eachplayer.gameObject.tag == "Player")
            {
                eachplayer.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
        }
        foreach (Transform eachplayer in eachPlayer2)
        {
            if (eachplayer.gameObject.tag == "Player")
            {
                eachplayer.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
        }
    }
}
