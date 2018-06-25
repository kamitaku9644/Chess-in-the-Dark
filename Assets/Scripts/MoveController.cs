using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour,IMove {
    
    GameObject playerCamera;
    public GameObject PlayerCamera
    {
        get { return playerCamera; }
    }


    GameManager gameManager;
    RayController rayController;

    bool look;
    Vector3 movePosition;

    public void Move(GameObject hittedSquare)
    {
        playerCamera = this.gameObject.transform.GetChild(1).gameObject;
        movePosition = hittedSquare.transform.localPosition;
        rayController.mainCamera.SetActive(false);
        
        if (!look)
        {
            playerCamera.transform.LookAt(movePosition);
            look = true;
        }
        playerCamera.SetActive(!rayController.mainCamera.activeSelf);
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, movePosition, Time.deltaTime * 0.8f);

        if(this.transform.localPosition == movePosition) { gameManager.MoveComp = true; }
        
    }
}
