using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float speed = 5f;
    private float jumpForce = 10f;
    private float rotateSpeed = 180f;
    private bool isGrounded = true;
    private float rotation;
    
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 movement;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        float moveRotation = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        rotation += moveRotation * rotateSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) {
            movement = transform.forward.normalized;
        } else if (Input.GetKey(KeyCode.S)) {
            movement = -transform.forward.normalized;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() {
        rb.MoveRotation(Quaternion.Euler(0f, rotation, 0f));
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

