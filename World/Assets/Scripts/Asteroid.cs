using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	private LineRenderer line; 
	public GameObject planet;
	public GameObject asteroid;
    public GameObject[] asteroids;
	public Color blue = new Color (129.0F,155.0f, 255.0f);
	
	void Start() {
		StartCoroutine(SpawnTimer());
		line = gameObject.AddComponent<LineRenderer>();
        line.startWidth = .3f;
		line.startColor = blue;
		line.endColor = blue;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		asteroids = GameObject.FindGameObjectsWithTag("Respawn");
        Vector3 wayPointPos = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
		for(int i =0; i < asteroids.Length; i++) {
			asteroids[i].transform.position = Vector3.MoveTowards(asteroids[i].transform.position, wayPointPos, 10f * Time.deltaTime);
			line.SetPosition(0, asteroids[i].transform.position);
 			line.SetPosition(1, planet.transform.position);
			asteroids[i].transform.Rotate(Vector3.forward * 70f * Time.deltaTime);
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
