using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FPSController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 12f;
    [SerializeField] GameObject cam;
    CharacterController controller;
    private Vector3 velocity;
    bool isGrounded;
    float rotationX;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);
        
        if (moveX == 0 && moveZ == 0)
        {
            velocity.x *= .8f;
            velocity.z *= .8f;
        }

        
        //rb.linearVelocity += new Vector3(0,Physics.gravity.y * Time.deltaTime,0);
        //velocity.y += Physics.gravity.y * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y = jumpForce;
        }
        controller.Move(velocity * Time.deltaTime);        
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -mouseSensitivity;
        rotationX = Math.Clamp(rotationX,-70,70);

        transform.Rotate(Vector3.up * mouseX);
        cam.transform.localRotation = Quaternion.Euler(rotationX,0,0);
    }
}
