using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerChilds : MonoBehaviour
{
    Rigidbody body;
 
    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    public void Death()
    {
        //permet l'explosion du corps lors de la mort
        gameObject.transform.parent = null;
        body.useGravity = true;
        body.isKinematic = false;
        body.AddExplosionForce(50,transform.position,30,20);
    }

}

