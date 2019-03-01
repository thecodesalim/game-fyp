using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float speed = 100f;
    public float distance = 3f;
    public Transform target;
    public Vector2 input;

    void Start() {
        Application.targetFrameRate = 60;
}
    // Update is called once per frame
    void Update() {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
             // Get movement of the finger since last frame
             Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if(Input.GetTouch(0).position.x < Screen.width/2) {
            
                Vector2 TouchDirection = Input.GetTouch(0).deltaPosition;
                Vector3 worldVector = Camera.main.ScreenToWorldPoint(new Vector3(TouchDirection.x, TouchDirection.y, 0));  
                
                Vector2 SpinDirection = new Vector2(TouchDirection.x - (Camera.main.pixelWidth * 0.5f), TouchDirection.y - (Camera.main.pixelHeight * 0.5f));
                
                transform.RotateAround(target.transform.position, Vector3.up, TouchDirection.x * 5 * Time.deltaTime);
                transform.RotateAround(target.transform.position, Vector3.right, TouchDirection.y * 5 * Time.deltaTime);
                
            // Y_Yaw.transform.eulerAngles = new Vector3(SpinDirection.y * 0.1f, 0f, 0f);
                
                transform.LookAt(target.transform.position);
            }
        }

         /* 
        if(Input.GetKey(KeyCode.Mouse0)) {
           
            input += new Vector2(Input.GetAxis("Mouse Y") , Input.GetAxis("Mouse X") ) * speed;
            Quaternion rotation = Quaternion.Euler(-input.x, input.y, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance);
            transform.localRotation = rotation;
            transform.localPosition = position;
            
        }
        */
    }
}