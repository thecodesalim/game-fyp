using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
  public TextMeshProUGUI scoreText;
  private int score = 1;
  
  void Start() {
     StartCoroutine(ScoreTimer()); 
  }
  IEnumerator ScoreTimer() {
    int j = score++;
    scoreText.text = j.ToString();
    yield return new WaitForSeconds(1f);
    StartCoroutine(ScoreTimer());
    }
}
