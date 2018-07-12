using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour ,IDestroy{

    [SerializeField] GameObject _destroyer;

    private GameObject defeatedPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") { defeatedPlayer = other.gameObject; }
        
    }

    public void SetDestroyer()
    {
        if (defeatedPlayer != null)
        {
            GameObject destroyer =(GameObject)Instantiate(_destroyer, new Vector3(0,0,0), Quaternion.identity);
            destroyer.transform.position = defeatedPlayer.transform.position;
            destroyer.transform.parent = defeatedPlayer.transform;
        }
    }





}
