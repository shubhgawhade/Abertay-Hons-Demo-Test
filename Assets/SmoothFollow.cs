using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //Attach this to your Camera/anything you want to interpolate
 public class SmoothFollow : MonoBehaviour
 {
     [SerializeField] private Transform player;
    
     public float mouseSensitivity;
     private float xRot;
     
     public float vertRotationSpeed=0.1f;
     public float horRotationSpeed=0.1f;
     
     Vector3 refPos;
     Vector3 refRot;
 
     void Update ()
     {
         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    
         print(mouseX + " " + mouseY);
         xRot -= mouseY;
         xRot = Mathf.Clamp(xRot, -90, 90);
    
         Quaternion finalVerLoc = Quaternion.Euler(xRot + transform.eulerAngles.x, mouseX + transform.eulerAngles.y, 0);
    
         // Quaternion finalHorLook = Quaternion.Euler(0, mouseX + player.transform.eulerAngles.y, 0);
         
         // player.transform.rotation = Quaternion.Slerp(player.transform.rotation, finalHorLook, horRotationSpeed *  Time.deltaTime);
         transform.rotation = Quaternion.Slerp(transform.rotation, finalVerLoc, vertRotationSpeed *  Time.deltaTime);
     }
 }
