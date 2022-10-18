using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;


    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 velocity = new Vector3(horizontalInput, 0, verticalInput);
        velocity.Normalize();

        velocity *= moveSpeed * Time.fixedDeltaTime;
        Vector3 dir = transform.rotation * velocity;
        
        _rb.MovePosition(transform.position + dir);
    }
}
