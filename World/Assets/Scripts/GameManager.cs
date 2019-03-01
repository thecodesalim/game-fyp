using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public bool gameHasStarted;
    BuildingSpawner buildingSpawner;
    Asteroid asteroidSpawner;
    // Start is called before the first frame update
    void Start() {
        buildingSpawner = GameObject.FindObjectOfType<BuildingSpawner>();
		asteroidSpawner = GameObject.FindObjectOfType<Asteroid>();
    }

    // Update is called once per frame
    void Update() {
        //// work on this bish 
    }

    public void StartGame() {
        gameHasStarted = true; 
        print(gameHasStarted);
        StartCoroutine(asteroidSpawner.SpawnTimer());
        StartCoroutine(buildingSpawner.SpawnTimer());
    }

}
