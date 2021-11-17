using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class Virtual_camera : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    PhotonView Pview;
    // Start is called before the first frame update
    void Start()
    {

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        Pview = GetComponentInParent<PhotonView>();

        if (!Pview.IsMine)
        {
            virtualCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
