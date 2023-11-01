using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameRoyaleManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] List<Transform> loactions;

    public bool setHealth = false;
    public static GameRoyaleManager instance;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        int RandomNUmber = (int)Random.Range(1f, loactions.Count);

        Vector3 RandomLocation = loactions[RandomNUmber].position;

        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, RandomLocation,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            Application.Quit();
        }
    }

    public override void OnJoinedRoom()
    {


        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
        setHealth = true;
       
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {


        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
        setHealth = true;
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLaucherScene");

    }





}
