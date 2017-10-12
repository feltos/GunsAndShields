﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField]
    GameObject BaseCanvas;
    [SerializeField]
    GameObject hostCanvas;
    [SerializeField]
    GameObject clientCanvas;
    [SerializeField]
    Text inputFieldText;
    [SerializeField]
    Text nameOfServer;

   public string GetUserServName()
    {
        return inputFieldText.text;
    }

    public void SetServeName(string newName)
    {
        nameOfServer.text = newName;
    }

    public void CreateGame()
    {
        BaseCanvas.SetActive(false);
        hostCanvas.SetActive(true);
    }

    public void JoinGame()
    {
        BaseCanvas.SetActive(false);
        clientCanvas.SetActive(true);
    }
}
