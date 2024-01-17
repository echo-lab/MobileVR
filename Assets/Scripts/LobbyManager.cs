using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void ClickedEnterRoom()
    {
        PhotonNetwork.LoadLevel(1); //load the Scene 1 (ARScene)
    }
}
