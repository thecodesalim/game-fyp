﻿using UnityEngine;
 using System.Collections;
 public class SpinLogic : MonoBehaviour {
 
    public Rigidbody rb;
     GameManager gameManager;
 
     void Start() {
         //Time.timeScale = 0.5f;
        rb = GetComponent<Rigidbody>();
        gameManager =  GameObject.FindObjectOfType<GameManager>(); 
     }
 
     void FixedUpdate() {
         print("spin " + gameManager.gameHasStarted);
         if(!gameManager.gameHasStarted){
             return;
         }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                if(Input.GetTouch(0).position.x > Screen.width/2){
                    rb.AddTorque(Camera.main.transform.up * -touchDeltaPosition.x);
                    rb.AddTorque(Camera.main.transform.right * touchDeltaPosition.y);
                
                }
         }

/*
         if(Input.GetMouseButton(0)){
            float h = Input.GetAxis("Mouse X") * 50f;   
            float v = Input.GetAxis("Mouse Y") * 50f;  
            print("yeah") ;
            rb.AddTorque(Camera.main.transform.up * -h);
            rb.AddTorque(Camera.main.transform.right * v);
         }
          */
     }
 }