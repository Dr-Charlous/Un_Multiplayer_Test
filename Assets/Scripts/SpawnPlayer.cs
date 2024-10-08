using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public float Xmin, Xmax, Ymin, Ymax;

    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(Xmin, Xmax), Random.Range(Ymin, Ymax));
        PhotonNetwork.Instantiate(PlayerPrefab.name, randomPosition, Quaternion.identity);
    }
}