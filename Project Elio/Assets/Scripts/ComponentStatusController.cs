using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ComponentStatusController : MonoBehaviourPun
{
    public GameObject myCam;

    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine)
        {
            myCam.SetActive(false);
        }
    }

}
