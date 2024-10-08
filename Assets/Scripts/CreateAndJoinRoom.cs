using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField CreateInput;
    public InputField JoinInput;

    public void CreateRoom()
    {
        if (CreateInput.text.Length > 0)
            PhotonNetwork.CreateRoom(CreateInput.text);
    }

    public void JoinRoom()
    {
        if (JoinInput.text.Length > 0)
            PhotonNetwork.JoinRoom(JoinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
