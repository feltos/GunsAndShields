using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    CharacterController controller;
    [SerializeField]
    float speed;
    [SerializeField]float rotateSpeed;
    [SerializeField]
    GameObject bullet;
    float horizontal;
    float vertical;
    Vector3 forward;
    Vector3 v;

	void Start ()
    {      
        Cursor.visible = true;
        controller = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        v = transform.right * speed * horizontal;
        forward = transform.forward * speed * vertical;
       
        controller.SimpleMove(forward + v);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            
        }

        

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
    }

    void FixedUpdate()
    {
        
    }
}
