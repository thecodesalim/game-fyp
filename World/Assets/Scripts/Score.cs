using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
  public TextMeshProUGUI scoreText;
  public float score = 1;
  private int waveLevel = 1;
  private int scoreToNextWave = 20;
  private int maxWaveLevel = 10;
  GameManager gameManager;
  Asteroid asteroid;
  
  void Start() 
  {
    asteroid = GameObject.FindObjectOfType<Asteroid>();
    gameManager = GameManager.Instance;
  }

  void Update() 
  {
    if(gameManager.gameHasStarted) {
      score += Time.deltaTime;
      scoreText.text = ((int)score).ToString();
      if(score >= scoreToNextWave) 
        NextWave();
    }
  }

    public float GetScore() 
    {
      return this.score;
    }

    void NextWave() 
    {
      if(waveLevel == maxWaveLevel)
       return;

      scoreToNextWave *= 2;
      waveLevel++;
      print("Wave level " + waveLevel);
      asteroid.IncreaseDifficulty(3);
    }

}
