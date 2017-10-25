using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    
    PlayerCharacter playerCharacter;
    [SerializeField]
    Text HPText;
    [SerializeField]
    Text MunText;
    const int maxHP = 100;
    const int maxMun = 25;
    const int minHp = 0;

    private void Start()
    {
        playerCharacter = gameObject.transform.parent.GetComponent<PlayerCharacter>();
    }

    void Update ()
    {
        if(playerCharacter.getHealth() > minHp)
        {
            HPText.text = "HP : " + playerCharacter.getHealth() + " / " + maxHP;
        }
        if(playerCharacter.getHealth() <= minHp)
        {
            HPText.text = "HP : " + minHp + " / " + maxHP;
        }
        MunText.text = "Mun : " + playerCharacter.GetBulletRemaining() + " / " + maxMun;
    }
}
