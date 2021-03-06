﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour,IMove {
    
    GameObject playerCamera;
    public GameObject PlayerCamera
    {
        get { return playerCamera; }
    }

    Vector3 movePosition;

    public virtual void MoveRdy(GameObject hittedSquare)
    {
        this.GetComponent<IMovable>().SSinit();
        playerCamera = this.gameObject.transform.GetChild(1).gameObject;
        movePosition = new Vector3(hittedSquare.transform.localPosition.x, -0.25f, hittedSquare.transform.localPosition.z);
        playerCamera.SetActive(true);
        playerCamera.transform.LookAt(this.gameObject.transform.parent.transform.TransformPoint(movePosition));
        
    }
    public void Move()
    {
           
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, movePosition, Time.deltaTime * 0.8f);
        
        if (this.transform.localPosition == movePosition) { GameManager.MoveComp = true; }

    }
    public void Moveinit()
    {
        if (playerCamera.activeSelf) { playerCamera.SetActive(false); }
    }

    

}
