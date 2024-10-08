using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_view.IsMine)
        {
            Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (inputDirection != Vector3.zero)
            {
                Vector3 movements = inputDirection * _speed * Time.deltaTime;
                transform.position += movements;
            }
        }
    }
}
