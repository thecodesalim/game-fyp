﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {
	private float delay = 1.5f;
	public GameObject planet;
	public GameObject[] building;

	// Use this for initialization
	void Start ()
	 {
		
	}

	// Instantiates a building gameObject and attaches it as child of the planet
	void InstantiateBuilding(Vector3 spawnPos) 
	{
		GameObject newCharacter = Instantiate(building[Random.Range(0, 5)], spawnPos, Quaternion.identity) as GameObject;
		newCharacter.transform.LookAt(planet.transform);
		newCharacter.transform.Rotate(180, 360, 0);
		newCharacter.transform.parent = planet.transform;
	}

	// Returns random spawn positions for the buildings
	Vector3 GetSpawnPosition () 
	{
		Vector3 spawnPosition = Random.onUnitSphere * (planet.GetComponent<SphereCollider>().radius + 15f * 0.5f) + planet.transform.position;
		return spawnPosition;
	}
	
	// Spawns a building depending on the timer
	public IEnumerator SpawnTimer() 
	{	
		InstantiateBuilding(GetSpawnPosition());
		yield return new WaitForSeconds(Random.Range(0.5f, 2f));
		StartCoroutine(SpawnTimer());
	}

	public void StartSpawn() {
		StartCoroutine(SpawnTimer());
	}

	public void StopSpawn() {
		StopAllCoroutines();
	}
}
