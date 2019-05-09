using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public float delay;
	public GameObject planet;
	public GameObject asteroid;
	public GameObject[] asteroids;
	private LineRenderer lr;
	public float speed = 13f;
	ObjectPooler objectPooler;
	void Start () {
		objectPooler = ObjectPooler.Instance;
	}

	// Update is called once per frame
	void FixedUpdate () {
		asteroids = GameObject.FindGameObjectsWithTag ("Respawn");
		Vector3 wayPointPos = new Vector3 (planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
		for (int i = 0; i < asteroids.Length; i++) {
			asteroids[i].transform.position = Vector3.MoveTowards (asteroids[i].transform.position, wayPointPos, speed * Time.deltaTime);
			createLine (asteroids[i]);
			asteroids[i].transform.Rotate (Vector3.forward * 70f * Time.deltaTime);
			asteroids[i].transform.parent = planet.transform;
		}
	}

	void createLine (GameObject i) {
		lr = i.GetComponent<LineRenderer> ();
		Material whiteDiffuseMat = new Material (Shader.Find ("Sprites/Default"));
		lr.material = whiteDiffuseMat;
		lr.startWidth = 0.1f;
		Color newColor = new Color (0.3f, 0.4f, 0.6f, 0.3f);
		lr.startColor = newColor;
		//lr.endColor = newColor;
		lr.SetPosition (0, i.transform.position);
		lr.SetPosition (1, planet.transform.position);
	}

	public IEnumerator SpawnTimer () {
		//GameObject spawnedAsteroid = Instantiate(asteroid, GetSpawnPosition(), Quaternion.identity); 
		GameObject spawnedAsteroid = objectPooler.SpawnFromPool ("asteroid", GetSpawnPosition (), Quaternion.identity);
		float rand = Random.Range (0f, 2.5f);
		print(rand);
		yield return new WaitForSeconds (rand);
		StartCoroutine (SpawnTimer ());
	}

	Vector3 GetSpawnPosition () {
		Vector3 spawnPosition = Random.onUnitSphere * (planet.GetComponent<SphereCollider> ().radius + 10f * 3f) + planet.transform.position;
		return spawnPosition;
	}

	public void IncreaseDifficulty (float modifier) {
		this.speed += 1f;
		//this.delay += 1f;
	}

	public void StopSpawn () {
		StopAllCoroutines ();
	}

	public void StartSpawn () {
		StartCoroutine (SpawnTimer ());
	}
}