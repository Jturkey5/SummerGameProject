using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float gravity = 9.81f;
    public float jumpForce = 7.0f;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    private Transform cameraTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 cameraForward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;

        moveDirection = cameraForward * moveInput.z + cameraTransform.right * moveInput.x;
        moveDirection *= moveSpeed;
        
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
