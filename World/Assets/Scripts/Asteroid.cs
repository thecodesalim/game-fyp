using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public GameObject planet;
	public GameObject asteroid;
    public GameObject[] asteroids;
    private float time = 50f;

	// Update is called once per frame
	void FixedUpdate () {
        time--;
		asteroids = GameObject.FindGameObjectsWithTag("Respawn");
        Vector3 wayPointPos = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
		
		for(int i =0; i < asteroids.Length; i++) {
			asteroids[i].transform.position = Vector3.MoveTowards(asteroids[i].transform.position, wayPointPos, 15f * Time.deltaTime);
			//asteroids[i].GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 50f;
			//asteroids[i].transform.parent = planet.transform;
		}
        int j = 0;
		if(time <= 0) {  
            print("done "+ j++);
			Instantiate(asteroid, new Vector3(Random.Range(-200,200), Random.Range(-200,200), 0), Quaternion.identity);
			time = 500f;
		}

        //float step = 50 * Time.deltaTime;
	    //asteroid.transform.position = Vector3.MoveTowards(asteroid.transform.position, planet.transform.position, step);
	}
}
