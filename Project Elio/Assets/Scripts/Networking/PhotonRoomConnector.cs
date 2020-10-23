using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonRoomConnector : MonoBehaviourPunCallbacks
{
    public Transform SpawnPosition;
    public GameObject CreatingText;
    public GameObject JoiningText;
    public GameObject InGameCanvas;

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        CreatingText.SetActive(false);
        JoiningText.SetActive(false);
        InGameCanvas.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Couldn't Join room: {message}");
        PhotonConnector.Instance.MainMenu.SetActive(true);
        InGameCanvas.SetActive(false);
        JoiningText.SetActive(false);
        CreatingText.SetActive(false);
    }
}
