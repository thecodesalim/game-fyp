using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour {
	private float spawnTime;
	public GameObject world;
	public GameObject[] building;
	// Use this for initialization
	void Start () {
		spawnTime = 50f;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTime--;
	
		if(spawnTime <= 0) {
			print("new building");
			InstantiateBuilding(SpawnPosition());
		}
	}

	// Instantiates a building gameObject and attaches it as child of the planet
	void InstantiateBuilding(Vector3 spawnPos) {
		GameObject newCharacter = Instantiate(building[Random.Range(0, 3)], spawnPos, Quaternion.identity) as GameObject;
		newCharacter.transform.LookAt(world.transform);
		newCharacter.transform.Rotate(180, 360, 0);
		newCharacter.transform.parent = world.transform;
		spawnTime = 150;
	}

	// Returns random spawn positions for the buildings
	Vector3 SpawnPosition () {
		Vector3 spawnPosition = Random.onUnitSphere * (world.GetComponent<SphereCollider>().radius + 15f * 0.5f) + world.transform.position;
		return spawnPosition;
	}
}
