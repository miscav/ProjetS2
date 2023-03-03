using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private GameObject instance;
    public static bool isLeavingRoom = false;

    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Esc pour sortir de la scene
    void Update()
    {     // Quit the Scene if Esc
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LeaveRoom();
        }
    }

    // Spawn du Player
    void Start()
    {
        Cursor.visible = true; 
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("MyLauncherScene");
            return;
        }
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            if (PlayerManager.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                instance = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(635, 538, -973), Quaternion.identity, 0);
                instance.tag = "MyPlayer";
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }
        }

    }

    // Affiche un message lors de l'arriv� du Player dans la Room
    public void OnPlayerEnterRoom(Player other)
    {
        Debug.Log(other.NickName + " is connected ! ");
    }


    // Affiche un message lors du d�part du Player de la Room
    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log(other.NickName + " is disconnected ! ");
    }

    // Programme ex�cut� en parall�le, utilise WaitToLeave
    public override void OnLeftRoom()
    {
            StartCoroutine(WaitToLeave());
    }


    // Si on quitte, cela nous renvoit sur la sc�ne du Launcher
    IEnumerator WaitToLeave()
    {
        while (PhotonNetwork.InRoom)
            yield return null;
        isLeavingRoom = false;
        SceneManager.LoadScene("MyLauncherScene");
    }


    // On notifie aux autres joueurs qu'un Player part, et on le d�connecte.
    public void LeaveRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " is leaving the Room");
        isLeavingRoom = true;
        PhotonNetwork.LeaveRoom();
    }


    // Fonction qui nous permet de quitter l'application 
    public void QuitApplication()
    {
        Application.Quit();
    }
     
}
