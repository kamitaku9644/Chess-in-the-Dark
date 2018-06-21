using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour{

    public GameObject MainCamera;

    GameObject hittedPlayer;
    bool playerHited;

	// Use this for initialization
	void Start () {
        playerHited = false;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (!playerHited)
            {
                hittedPlayer = hit.collider.gameObject;
                hittedPlayer.GetComponent<IMovable>().Movable();
                playerHited = true;
            }
        }else if(playerHited)
        {
            hittedPlayer.GetComponent<IMovable>().SSinit();
            playerHited = false;
        }
	}
}
