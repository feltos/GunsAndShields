using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void PlaySoundTarget()
    {
        GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
