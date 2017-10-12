using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCharacter : NetworkBehaviour
{
    CharacterController controller;
    [SerializeField]
    float speed;
    [SerializeField]float rotateSpeed;
    [SerializeField]
    GameObject bullet;
    GameObject tempBullet;
    float horizontal;
    float vertical;
    Vector3 forward;
    Vector3 v;
    Vector3 up;
    [SerializeField]
    GameObject camera;
    [SerializeField]float gravity;
    [SerializeField]
    GameObject bulletSpawn;
    [SerializeField][SyncVar]int playerID  = -1;

    [SerializeField]
    int health;


    public int PlayerID
    {
        get
        {
            return playerID;
        }

        set
        {
            playerID = value;
        }
    }

    void Start ()
    {      
        controller = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
               
        v = transform.right * speed * horizontal;
        forward = transform.forward * speed * vertical;
        up = transform.up;
        controller.SimpleMove(forward + v);
       
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            //Debug.Log("niquetamere");
            //controller.SimpleMove(up * gravity);
        }
      
        if(Input.GetButtonDown("Fire1"))
        {
            CmdShoot(bulletSpawn.transform.position,bulletSpawn.transform.rotation);
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
        camera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * rotateSpeed);
    }

    public override void OnStartLocalPlayer()
    {
        camera.SetActive(true);
    }

    void FixedUpdate()
    {
       
    }

    [Command]
    void CmdShoot(Vector3 bulletSpawnPos,Quaternion bulletSpawnRot)
    {
        tempBullet = Instantiate(bullet,bulletSpawnPos,bulletSpawnRot);
        NetworkServer.Spawn(tempBullet);
    }
}
