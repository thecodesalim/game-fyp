using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float speed = 120f;
    public float distance = 3f;
    public Transform target;
    public Vector2 input;

    void Start() {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void LateUpdate() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
        {
             // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if(Input.GetTouch(0).position.x < Screen.width/2) 
            {
                transform.RotateAround(target.transform.position, Camera.main.transform.up , -touchDeltaPosition.x * speed);
                transform.RotateAround(target.transform.position, Camera.main.transform.right , touchDeltaPosition.y * speed);
                //rb.AddTorque( Vector3.up * -touchDeltaPosition.x);
                //rb.AddTorque(Vector3.right * touchDeltaPosition.y);
                //transform.LookAt(target.transform.position);    
            }

        }

        

        
        

            
    
    }
    
}