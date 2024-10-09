using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField CreateInput;
    public InputField JoinInput;
    public TextMeshProUGUI TextError;

    private void Start()
    {
        if (TextError.gameObject.activeInHierarchy)
            TextError.gameObject.SetActive(false);
    }

    public void CreateRoom()
    {
        if (CreateInput.text.Length > 0)
        {
            if (TextError.gameObject.activeInHierarchy)
                TextError.gameObject.SetActive(false);
            PhotonNetwork.CreateRoom(CreateInput.text);
        }
        else
        {
            TextError.gameObject.SetActive(true);
            TextError.text = "You need a code to create a room";
        }
    }

    public void JoinRoom()
    {
        if (JoinInput.text.Length > 0)
        {
            if (TextError.gameObject.activeInHierarchy)
                TextError.gameObject.SetActive(false);
            PhotonNetwork.JoinRoom(JoinInput.text);
        }
        else
        {
            TextError.gameObject.SetActive(true);
            TextError.text = "You need a code to join a room";
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        TextError.gameObject.SetActive(true);
        TextError.text = "This room doesn't exist";
    }
}
