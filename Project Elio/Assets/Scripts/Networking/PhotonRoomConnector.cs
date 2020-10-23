using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonRoomConnector : MonoBehaviourPunCallbacks
{
    public Transform SpawnPosition;
    public GameObject CreatingText;

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        CreatingText.SetActive(false);
    }
}
