using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class CameraSetup : MonoBehaviour
{
    private PhotonView photonView;

    public GameObject ARCamera;

    public GameObject VRCamera;


    void Start()
    {
        VRCamera = GameObject.FindGameObjectWithTag("Player");
        ARCamera = GameObject.FindGameObjectWithTag("MainCamera");

        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            this.gameObject.tag = "Myself";
        }
    }

    void Update()
    {
        VRCamera.transform.position = ARCamera.transform.position;
        VRCamera.transform.rotation = ARCamera.transform.rotation;
    }
}

