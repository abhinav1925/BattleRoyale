using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchScript : MonoBehaviourPunCallbacks
{

    public GameObject BeforeConnecting;
    public GameObject TryingtoConnect;
    public GameObject AfterConnection;
    // Start is called before the first frame update
    void Start()
    {
        BeforeConnecting.SetActive(true);
        TryingtoConnect.SetActive(false);
        AfterConnection.SetActive(false);

    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            Application.Quit();
        }
    }

    public void ConnectToPhoton()
    {  if(!PhotonNetwork.IsConnected)
        {
            BeforeConnecting.SetActive(false);
            TryingtoConnect.SetActive(true);
            PhotonNetwork.ConnectUsingSettings();
        }
       
    }
        
    public override void OnConnectedToMaster()
    {
        TryingtoConnect.SetActive(false);
        AfterConnection.SetActive(true);
        Debug.Log(PhotonNetwork.NickName +  " Connected to Phototn");

    }

    public void JoinRandomRoom1()
    {
        PhotonNetwork.JoinRandomRoom();



    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        

        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
       
        Debug.Log(message);
        CreatingRoom();
      

    }

    private void CreatingRoom()
    {
        string RoomName = "Room" + Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.CreateRoom(RoomName,roomOptions);
    }

    public override void OnJoinedRoom()
    {
        

        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene");
    }

}
