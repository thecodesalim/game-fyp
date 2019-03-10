using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public bool gameHasStarted;
    public GameObject CanvasObject;
    BuildingSpawner buildingSpawner;
    Asteroid asteroidSpawner;
    Score score;
    // Start is called before the first frame update
    void Start() 
    {
        buildingSpawner = GameObject.FindObjectOfType<BuildingSpawner>();
		asteroidSpawner = GameObject.FindObjectOfType<Asteroid>();
        score = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update() 
    {
       if(Input.GetKeyDown("space")) {
           asteroidSpawner.StopSpawn();
           buildingSpawner.StopSpawn();
           print("Spaced OUT");
           print("Spaced OUT");
           print("Spaced OUT");
           print("Spaced OUT");
       }
    }

    public void StartGame() 
    {
        gameHasStarted = true; 
        if(gameHasStarted) 
        {
            CanvasObject.GetComponent<Canvas> ().enabled = false;
            asteroidSpawner.StartSpawn();
            buildingSpawner.StartSpawn();
        }
        
    }

    public void EndGame()
    {
        gameHasStarted = false;
        float newScore = score.GetScore();
        if(newScore > PlayerPrefs.GetInt("Best"))
            PlayerPrefs.SetInt("Best", (int)newScore);
        //print(PlayerPrefs.GetInt("Best"));
    } 
}
