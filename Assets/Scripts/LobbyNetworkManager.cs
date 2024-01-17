 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;
public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject JoinedRoomPanel;
    public void ClickedHeadsetUser()
    {
        StartCoroutine(EnableJoinedRoomPanelAfterFewSeconds()); //wait for few seconds to connect the server
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Try Connect to Server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server");
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby(); //if the server is connected, automatically joined the lobby
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby");

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //do nothing
        }
        else
        {
            PhotonNetwork.LoadLevel(0); // go back to lobby
        }

    }
    public void InitializeRoom() //join or create room1
    {
        //Room option
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = 10,
            IsVisible = true,
            IsOpen = true,
            PublishUserId = true
        };

        PhotonNetwork.JoinOrCreateRoom("ARScene", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player entered the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    IEnumerator EnableJoinedRoomPanelAfterFewSeconds()
    {
        yield return new WaitForSeconds(2.5f);
        JoinedRoomPanel.SetActive(true);
    }
}
