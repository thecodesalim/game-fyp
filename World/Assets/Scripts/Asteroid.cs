﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public GameObject planet;
	public GameObject asteroid;
    public GameObject[] asteroids;
	
	void Start() {
		StartCoroutine(SpawnTimer());
	}

	// Update is called once per frame
	void FixedUpdate () {
		asteroids = GameObject.FindGameObjectsWithTag("Respawn");
        Vector3 wayPointPos = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
		
		for(int i =0; i < asteroids.Length; i++) {
			asteroids[i].transform.position = Vector3.MoveTowards(asteroids[i].transform.position, wayPointPos, 15f * Time.deltaTime);
			asteroids[i].transform.Rotate(Vector3.up * Time.deltaTime * 90f);
		}
	}

	IEnumerator SpawnTimer() {
		print("New Asteroid Spawned");
		Vector3 spawnPosition = Random.onUnitSphere * (planet.GetComponent<SphereCollider>().radius + 15f * 8f) + planet.transform.position;
		Instantiate(asteroid, spawnPosition, Quaternion.identity); 
		yield return new WaitForSeconds(7f);
		StartCoroutine(SpawnTimer());
	}
}
