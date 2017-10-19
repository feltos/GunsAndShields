using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerChilds : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    Rigidbody body;
 
    private void Start()
    {
        playerCharacter = gameObject.transform.parent.GetComponent<PlayerCharacter>();
        body = gameObject.GetComponent<Rigidbody>();
    }

    public void Death()
    {
        gameObject.transform.parent = null;
        body.useGravity = true;
        body.isKinematic = false;
    }

}

