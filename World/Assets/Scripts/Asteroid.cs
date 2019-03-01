﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	private float timer = 2f;
	private LineRenderer line; 
	public GameObject planet;
	public GameObject asteroid;
    public GameObject[] asteroids;
	public float speed = 12f;
	void Start() {
		CreateLineUI();
	}

	// Update is called once per frame
	void FixedUpdate() {
		asteroids = GameObject.FindGameObjectsWithTag("Respawn");
        Vector3 wayPointPos = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
		for(int i =0; i < asteroids.Length; i++) {
			asteroids[i].transform.position = Vector3.MoveTowards(asteroids[i].transform.position, wayPointPos, speed * Time.deltaTime);
			line.SetPosition(0, asteroids[i].transform.position);
 			line.SetPosition(1, planet.transform.position);
			asteroids[i].transform.Rotate(Vector3.forward * 70f * Time.deltaTime);
			asteroids[i].transform.parent = planet.transform;
			
		}
	}

	void CreateLineUI() {
		line = gameObject.AddComponent<LineRenderer>();
		Material whiteDiffuseMat = new Material(Shader.Find ("Sprites/Default"));
		line.material = whiteDiffuseMat;
        line.startWidth = .1f;
		line.startColor = Color.red;
		line.endColor = Color.red;
	}

	public IEnumerator SpawnTimer() {
		Vector3 spawnPosition = Random.onUnitSphere * (planet.GetComponent<SphereCollider>().radius + 15f * 8f) + planet.transform.position;
		Instantiate(asteroid, spawnPosition, Quaternion.identity); 
		yield return new WaitForSeconds(timer);
		StartCoroutine(SpawnTimer());
	}
}
