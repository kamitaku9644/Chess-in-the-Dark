using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour,IMove {
    public GameObject mainCamera;
    public GameObject playerCamera;

    bool look;
    Vector3 movePosition;

    public void Move(GameObject hittedSquare)
    {
        movePosition = hittedSquare.transform.localPosition;
        mainCamera.SetActive(false);
        
        if (!look)
        {
            playerCamera.transform.LookAt(movePosition);
            look = true;
        }
        playerCamera.SetActive(!mainCamera.activeSelf);
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, movePosition, Time.deltaTime * 0.8f);
        
    }
}
