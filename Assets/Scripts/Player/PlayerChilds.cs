using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChilds : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    Rigidbody body;

    private void Start()
    {
        playerCharacter = gameObject.transform.parent.GetComponent<PlayerCharacter>();
        body = gameObject.GetComponent<Rigidbody>();
    }

    void Update ()
    {
        Debug.Log(playerCharacter.getHealth());
		if(playerCharacter.getHealth() <= 0)
        {
            gameObject.transform.parent = null;
            body.useGravity = true;
            body.isKinematic = false;
        }
	}
}
