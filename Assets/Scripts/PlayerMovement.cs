using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Movement")]
    public float speed;
    public float force;
    public float groundDrag;

    [Header("Ground Check")]
    public float Heigth;
    public LayerMask isGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movedirection;

    Rigidbody rb;
    #endregion
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, Heigth * 0.5f + 0.2f, isGround);

        SpeedControl();
        PlayerInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        PlayerMovements();
    }
    
    private void PlayerInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovements()
    {
        movedirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(movedirection.normalized * speed * force, ForceMode.Force);
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }
    
}
