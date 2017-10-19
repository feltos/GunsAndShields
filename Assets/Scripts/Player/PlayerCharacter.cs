using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
    [SerializeField]
    GameObject camera;
    [SerializeField]float gravity;
    [SerializeField]float jumpSpeed;
    [SerializeField]
    GameObject bulletSpawn;
    [SerializeField][SyncVar]int playerID  = -1;

    [SerializeField][SyncVar]
    int health;
    PlayerChilds []playerChilds;
    const int firstChild = 0;
    [SyncVar]
    int bulletRemaining = 25;
    bool die = false;

    Vector3 movedirection = Vector3.zero;
    [SerializeField]
    Canvas playerUI;
    [SerializeField]
    Canvas gameOverUI;

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

    public int getHealth()
    {
        return health;
    }

    public int SetHealth()
    {
        return health -= 10;
    }

    public int GetBulletRemaining()
    {
        return bulletRemaining;
    }

    void Start ()
    {      
        controller = GetComponent<CharacterController>();
        playerChilds = GetComponentsInChildren<PlayerChilds>();
	}
	
	void Update ()
    {
        Debug.Log(die);
        if(!isLocalPlayer)
        {
            return;
        }
        if(!die)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            v = transform.right * speed * horizontal;
            forward = transform.forward * speed * vertical;         


            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                movedirection.y = jumpSpeed;
            }

            if (Input.GetButtonDown("Fire1") && bulletRemaining > 0)
            {
                CmdShoot(bulletSpawn.transform.position, camera.transform.rotation);
            }

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
            camera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * rotateSpeed);
            if (health <= 0 && !die)
            {
                Die();
            }
            if(controller.isGrounded == false)
            {
                movedirection.y -= gravity * Time.deltaTime;
            }
            
            controller.Move(movedirection);
            controller.SimpleMove(forward + v);
        }     
    }

    public override void OnStartLocalPlayer()
    {
        camera.SetActive(true);
        playerUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
    }

    [Command]
    void CmdShoot(Vector3 bulletSpawnPos,Quaternion bulletSpawnRot)
    {
        tempBullet = Instantiate(bullet,bulletSpawnPos,bulletSpawnRot);
        NetworkServer.Spawn(tempBullet);
        bulletRemaining--;
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            SetHealth();
            NetworkServer.Destroy(other.gameObject);
        }
      if(other.gameObject.layer == LayerMask.NameToLayer("MunBox"))
        {
            bulletRemaining = 25;
        }
    }
    void Die()
    {
        Debug.Log("die");
        die = true;
        CmdSetDie(die);
        RpcDeathPlayer();
        playerUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
    }

    [Command]
    void CmdSetDie(bool die)
    {
        Debug.Log("cmdSetDie");
        this.die = die;
    }

    [ClientRpc]
    void RpcDeathPlayer()
    {
        foreach(PlayerChilds child in playerChilds)
        {
            child.Death();
        }
    }
}
