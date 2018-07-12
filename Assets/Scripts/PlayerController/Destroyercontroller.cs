using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyercontroller : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RayController.HittedPlayer)
        {

            Destroy(this.gameObject.transform.parent.gameObject);

        }
    }
}
