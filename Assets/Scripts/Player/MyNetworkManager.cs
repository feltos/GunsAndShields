using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{

    [SerializeField]
    private int playerIDCount = 0;
    [SerializeField]
    Transform[] playerSpawnPos;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        var player = (GameObject)GameObject.Instantiate(playerPrefab, playerSpawnPos[playerIDCount % 2].transform.position, Quaternion.identity);
        player.GetComponent<PlayerCharacter>().PlayerID = playerIDCount;
        playerIDCount++;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
