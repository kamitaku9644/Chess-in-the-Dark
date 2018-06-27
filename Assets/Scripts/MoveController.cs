using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour,IMove {
    
    GameObject playerCamera;
    public GameObject PlayerCamera
    {
        get { return playerCamera; }
    }

    

    GameObject maincamera;
    bool look;
    Vector3 movePosition;

    public void MoveRdy(GameObject hittedSquare)
    {
        this.GetComponent<IMovable>().SSinit();
        playerCamera = this.gameObject.transform.GetChild(1).gameObject;
        movePosition = hittedSquare.transform.localPosition;
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
        playerCamera.SetActive(false);
    }
}
