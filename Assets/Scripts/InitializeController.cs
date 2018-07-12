using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeController : MonoBehaviour {
    
    
    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject bishop;
    [SerializeField] private GameObject king;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject queen;
    [SerializeField] private GameObject rook;
    [SerializeField] private GameObject swordman;

   

    public void PlayerInit(GameObject player)
    {
        Transform parent = player.transform;
        LayerController layerController = gameObject.AddComponent<LayerController>();
        
        Instantiate(king, parent.transform.TransformPoint(0.5f, -0.25f, -5.5f), parent.rotation, parent);
        Instantiate(queen, parent.transform.TransformPoint(-0.5f, -0.25f, -5.5f), parent.rotation, parent);
        Instantiate(bishop, parent.transform.TransformPoint(1.5f, -0.25f, -5.5f), parent.rotation, parent);
        Instantiate(bishop, parent.transform.TransformPoint(-1.5f, -0.25f, -5.5f), parent.rotation, parent);
        Instantiate(rook, parent.transform.TransformPoint(5.5f, -0.25f, -5.5f), parent.rotation, parent);
        Instantiate(rook, parent.transform.TransformPoint(-5.5f, -0.25f, -5.5f), parent.rotation, parent);
        for (float i = -4.5f; i < 6; i += 2)
        {
            Instantiate(archer, parent.transform.TransformPoint(i, -0.25f, -4.5f),parent.rotation, parent);
        }
        for (float i = -5.5f; i < 6; i += 2)
        {
            Instantiate(swordman, parent.transform.TransformPoint(i, -0.25f, -4.5f), parent.rotation, parent);
        }
        for (float i = -4.5f; i < -2; i++)
        {
            Instantiate(knight, parent.transform.TransformPoint(i, -0.25f, -5.5f), parent.rotation, parent);
        }
        for (float i = 4.5f; 2 < i; i--)
        {
            Instantiate(knight, parent.transform.TransformPoint(i, -0.25f, -5.5f), parent.rotation, parent);
        }

        layerController.SetLayer(player,player);
        Destroy(layerController);
    }

   
    

}
