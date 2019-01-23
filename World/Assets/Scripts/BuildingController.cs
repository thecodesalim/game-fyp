using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {
	public GameObject world;
	// Update is called once per frame
	void Update () {
		print(transform.position);
		print(world.transform.position + " world");
	}
}
