using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{ 
    [SerializeField] private Transform player;
    
    public float mouseSensitivity;
    private float xRot;
    
    private void Awake()
    {
        GameManager.MouseSensitivity = mouseSensitivity;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);
    
            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    
            player.Rotate(Vector3.up * mouseX);
    }
}
