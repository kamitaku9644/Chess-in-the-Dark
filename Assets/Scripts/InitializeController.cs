using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeController : MonoBehaviour {
    public GameObject player1;
    
    public GameObject archer;
    public GameObject bishop;
    public GameObject king;
    public GameObject knight;
    public GameObject queen;
    public GameObject rook;
    public GameObject swordman;

    
    public void Player1Init()
    {
        Transform parent = player1.transform;

        Instantiate(king, parent.transform.TransformPoint(0.5f, 0, -5.5f), parent.rotation, parent);
        Instantiate(queen, parent.transform.TransformPoint(-0.5f, 0, -5.5f), parent.rotation, parent);
        Instantiate(bishop, parent.transform.TransformPoint(1.5f, 0, -5.5f), parent.rotation, parent);
        Instantiate(bishop, parent.transform.TransformPoint(-1.5f, 0, -5.5f), parent.rotation, parent);
        Instantiate(rook, parent.transform.TransformPoint(5.5f, 0, -5.5f), parent.rotation, parent);
        Instantiate(rook, parent.transform.TransformPoint(-5.5f, 0, -5.5f), parent.rotation, parent);
        for (float i = -4.5f; i < 6; i += 2)
        {
            Instantiate(archer, parent.transform.TransformPoint(i, 0, -4.5f),parent.rotation, parent);
        }
        for (float i = -5.5f; i < 6; i += 2)
        {
            Instantiate(swordman, parent.transform.TransformPoint(i, 0, -4.5f), parent.rotation, parent);
        }
        for (float i = -4.5f; i < -2; i++)
        {
            Instantiate(knight, parent.transform.TransformPoint(i, 0, -5.5f), parent.rotation, parent);
        }
        for (float i = 4.5f; 2 < i; i--)
        {
            Instantiate(knight, parent.transform.TransformPoint(i, 0, -5.5f), parent.rotation, parent);
        }

    }

}
