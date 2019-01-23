using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20f;
    public float distance = 3f;
    public Transform target;
    public Vector2 input;

    // Update is called once per frame
    void LateUpdate() {
        input += new Vector2(Input.GetAxis("Mouse Y")* speed, Input.GetAxis("Mouse X") * speed);
        Quaternion rotation = Quaternion.Euler(input.x, input.y, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);
        transform.localRotation = rotation;
        transform.localPosition = position;
    }
}
