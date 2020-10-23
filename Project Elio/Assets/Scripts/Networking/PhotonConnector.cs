using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonConnector : MonoBehaviourPunCallbacks
{
    public static PhotonConnector Instance;

    public GameObject ConnectingText;
    public GameObject MainMenu;

    public TextMeshProUGUI JoinRoomField;
    public TextMeshProUGUI RoomTextField;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        ConnectingText.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void CreateGame()
    {
        const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want
        string roomName = "";

        for(int i=0; i < 5; i++)
        {
            roomName += glyphs[Random.Range(0, glyphs.Length)];
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
        Debug.Log($"Creating room: " + roomName);

        RoomTextField.text = roomName;
    }

    public void JoinGame()
    {
        Debug.Log($"Joining: {JoinRoomField.text}");
        PhotonNetwork.JoinRoom(JoinRoomField.text);
    }
}
