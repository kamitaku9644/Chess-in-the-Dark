using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour,IMove {
    
    public GameObject playerCamera;
    GameManager gameManager = new GameManager();

    bool look;
    Vector3 movePosition;

    public void Move(GameObject hittedSquare)
    {
        playerCamera = this.gameObject.transform.GetChild(1).gameObject;
        movePosition = hittedSquare.transform.localPosition;
        gameManager.mainCamera.SetActive(false);
        
        if (!look)
        {
            playerCamera.transform.LookAt(movePosition);
            look = true;
        }
        playerCamera.SetActive(!gameManager.mainCamera.activeSelf);
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, movePosition, Time.deltaTime * 0.8f);

        if(this.transform.localPosition == movePosition) { gameManager.moveComp = true; }
        
    }
}
