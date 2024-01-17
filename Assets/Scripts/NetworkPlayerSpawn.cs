using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawn : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    public Camera VRCamera;

    private void Start()
    {
        VRCamera.enabled = false;
        StartCoroutine(InstantiateViewFinderCamerAfterFewSeconds());
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

    IEnumerator InstantiateViewFinderCamerAfterFewSeconds()
    {
        yield return new WaitForSeconds(3f);
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("ViewFinderCamera", transform.position, transform.rotation);
        VRCamera.enabled = true;
    }
}
