using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public float delay = 2.5f;
	private LineRenderer line; 
	public GameObject planet;
	public GameObject asteroid;
    public GameObject[] asteroids;
	private LineRenderer lr;
	public float speed = 12f;
	void Start() 
	{
		
	}

	// Update is called once per frame
	void FixedUpdate() 
	{
		asteroids = GameObject.FindGameObjectsWithTag("Respawn");
        Vector3 wayPointPos = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
		for(int i =0; i < asteroids.Length; i++) 
		{
			asteroids[i].transform.position = Vector3.MoveTowards(asteroids[i].transform.position, wayPointPos, speed * Time.deltaTime);
			createLine(asteroids[i]);
			asteroids[i].transform.Rotate(Vector3.forward * 70f * Time.deltaTime);
			asteroids[i].transform.parent = planet.transform;	
		}
	}

	void createLine(GameObject i) 
	{
		lr  = i.GetComponent<LineRenderer>();
		Material whiteDiffuseMat = new Material(Shader.Find ("Sprites/Default"));
		lr.material = whiteDiffuseMat;
		lr.startWidth = .1f;
		lr.startColor = Color.white;
		lr.endColor = Color.white;
		lr.SetPosition(0, i.transform.position);
 		lr.SetPosition(1, planet.transform.position);
	}

	public IEnumerator SpawnTimer() 
	{
		GameObject spawnedAsteroid = Instantiate(asteroid, GetSpawnPosition(), Quaternion.identity); 
		line = spawnedAsteroid.AddComponent<LineRenderer>();
		yield return new WaitForSeconds(delay);
		StartCoroutine(SpawnTimer());
	}

	Vector3 GetSpawnPosition() {
		Vector3 spawnPosition = Random.onUnitSphere * (planet.GetComponent<SphereCollider>().radius + 15f * 3f) + planet.transform.position;
		return spawnPosition;
	}

	public void IncreaseDifficulty(float modifier) 
	{
        this.speed += modifier;
		this.delay += 0.5f;
    }

	 public void StopSpawn() {
		StopAllCoroutines();
	}

	public void StartSpawn() {
		StartCoroutine(SpawnTimer());
	}
}
