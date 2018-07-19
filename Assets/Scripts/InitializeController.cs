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
        
        GameObject obj = Instantiate(king, parent.transform.TransformPoint(0.5f, -0.25f, -5.5f), parent.rotation, parent);
        obj.name = "King";
        obj = Instantiate(queen, parent.transform.TransformPoint(-0.5f, -0.25f, -5.5f), parent.rotation, parent);
        obj.name = "Queen";
        obj = Instantiate(bishop, parent.transform.TransformPoint(1.5f, -0.25f, -5.5f), parent.rotation, parent);
        obj.name = "Bishop";
        obj = Instantiate(bishop, parent.transform.TransformPoint(-1.5f, -0.25f, -5.5f), parent.rotation, parent);
        obj.name = "Bishop";
        obj = Instantiate(rook, parent.transform.TransformPoint(5.5f, -0.25f, -5.5f), parent.rotation, parent);
        obj.name = "Rook";
        obj = Instantiate(rook, parent.transform.TransformPoint(-5.5f, -0.25f, -5.5f), parent.rotation, parent);
        obj.name = "Rook";
        for (float i = -4.5f; i < 6; i += 2)
        {
            obj = Instantiate(archer, parent.transform.TransformPoint(i, -0.25f, -4.5f),parent.rotation, parent);
            obj.name = "Archer";
        }
        for (float i = -5.5f; i < 6; i += 2)
        {
            obj = Instantiate(swordman, parent.transform.TransformPoint(i, -0.25f, -4.5f), parent.rotation, parent);
            obj.name = "Swordman";
        }
        for (float i = -4.5f; i < -2; i++)
        {
            obj = Instantiate(knight, parent.transform.TransformPoint(i, -0.25f, -5.5f), parent.rotation, parent);
            obj.name = "Knight";
        }
        for (float i = 4.5f; 2 < i; i--)
        {
            obj = Instantiate(knight, parent.transform.TransformPoint(i, -0.25f, -5.5f), parent.rotation, parent);
            obj.name = "Knight";
        }

        layerController.SetLayer(player,player);
        Destroy(layerController);
    }

   
    

}
