using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10, _speedLimit = 2;
    [SerializeField] float _jumpForce = 2;

    [SerializeField] Color _color;
    public SpriteRenderer SpriteRenderer;

    public PhotonView View;
    [SerializeField] Rigidbody2D _rb;

    private void Start()
    {
        View = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (View.IsMine)
        {
            float xInput = Input.GetAxis("Horizontal");
            Vector3 direction = Vector3.zero;

            if (xInput != 0 && _rb.velocity.x <= _speedLimit && _rb.velocity.x >= -_speedLimit)
            {
                direction += Vector3.right * xInput * _speed;
            }

            _rb.AddForce(direction);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
