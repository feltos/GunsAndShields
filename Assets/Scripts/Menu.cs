using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Menu : NetworkDiscovery
{
    NetworkManager networkManager;
    string ipAdress = null;
    Lobby lobby;
    string serverName;
    


    private void Start()
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        lobby = gameObject.GetComponent<Lobby>();
        
    }

    public void CreateServeur()
    {
        Initialize();
        serverName = lobby.GetUserServName();
        broadcastData = serverName;
        StartAsServer();
        networkManager.StartHost();
    }

    public void JoinServer()
    {
        Initialize();
        StartAsClient();
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        base.OnReceivedBroadcast(fromAddress, data);
        ipAdress = fromAddress;
        lobby.SetServeName(data);
    }

    public void Connect()
    {
        networkManager.networkAddress = ipAdress;
        networkManager.StartClient();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

 
}
