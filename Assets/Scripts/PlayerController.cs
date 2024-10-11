using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Camera playerCamera;
    private CharacterController controller;
    private float verticalRotation = 0f;

    public PhotonView View;
    public Renderer Renderer;
    public GameObject Head;
    public AudioListener audioListener;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Verrouille le curseur au centre

        if (!View.IsMine)
        {
            playerCamera.enabled = false;
            Head.SetActive(true);
            audioListener.enabled = false;
        }
        else
        {
            playerCamera.enabled = true;
            Head.SetActive(false);
            audioListener.enabled = true;
        }
    }

    void Update()
    {
        if (View.IsMine)
        {
            // Mouvement
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            controller.Move(move * speed * Time.deltaTime);

            // Rotation de la caméra
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limite la rotation verticale
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
