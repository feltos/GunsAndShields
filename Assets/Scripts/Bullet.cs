using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]int force;

	void Start ()
    {
        Destroy(gameObject, 5f);
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * force);
	}
	
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {

    }
}
