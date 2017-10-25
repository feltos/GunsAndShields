﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]int force;
    public Vector3 direction;

	void Start ()
    {
        Destroy(gameObject, 10f);
        gameObject.GetComponent<Rigidbody>().AddForce(direction * force);
	}
	
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {

    }
}