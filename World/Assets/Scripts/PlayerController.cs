using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector2 input;
	private float speed = 50f;


	void Start() {
		//Time.timeScale = 0.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(Input.GetKey(KeyCode.Mouse0)) {
			input += new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * speed;
			Quaternion rotation = Quaternion.Euler(input.x, input.y, 0);
			transform.localRotation = rotation;
		}
	}

	void OnMouseDrag() {
		//input += new Vector2(Input.GetAxis("Mouse Y")* speed, Input.GetAxis("Mouse X") * speed);
        //Quaternion rotation = Quaternion.Euler(input.x, input.y, 0);
		//transform.localRotation = rotation;
		
	}

	//float _vertical = Input.GetAxis("Mouse Y");
		//float _horizontal = Input.GetAxis("Mouse X");
		//transform.Rotate(new Vector3(_vertical, -_horizontal, 0f)* speed);
		//if(Input.touchCount == 1) {
			//transform.Rotate(new Vector3(Input.touches[0].deltaPosition.x * 0.5f, Input.touches[0].deltaPosition.y * 0.5f, 0f));
		//}
}
