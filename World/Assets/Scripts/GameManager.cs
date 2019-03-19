using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool gameHasStarted;
    public GameObject CanvasObject;
    public GameObject gameOverScreen;
    BuildingSpawner buildingSpawner;
    Asteroid asteroidSpawner;
    Leaderboard leaderboard;
    Score score;
    public static GameManager Instance;
    
    private void Awake() 
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() 
    {
        buildingSpawner = GameObject.FindObjectOfType<BuildingSpawner>();
		asteroidSpawner = GameObject.FindObjectOfType<Asteroid>();
        score = GameObject.FindObjectOfType<Score>();
        leaderboard = GameObject.FindObjectOfType<Leaderboard>();
    }

    public void StartGame() 
    {
        gameHasStarted = true; 
        if(gameHasStarted) 
        {
            CanvasObject.SetActive(false);
            asteroidSpawner.StartSpawn();
            buildingSpawner.StartSpawn();
        }
        
    }

    public void EndGame()
    {
        gameHasStarted = false;
        float newScore = score.GetScore();
        if(newScore > PlayerPrefs.GetInt("Best")) {
            PlayerPrefs.SetInt("Best", (int)newScore);
            leaderboard.ReportScore(PlayerPrefs.GetInt("Best"), "PR_LEADERBOARD");
        }
        asteroidSpawner.StopSpawn();
        buildingSpawner.StopSpawn();
        //gameOverScreen.GetComponent<Canvas>().enabled = true;
        gameOverScreen.SetActive(true);
        print(gameOverScreen);
    } 

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
