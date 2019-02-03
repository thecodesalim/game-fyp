using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
  public TextMeshProUGUI scoreText;
  public int score = 1;
  public int j = 0;
  
  void Start() {
     StartCoroutine(ScoreTimer()); 
  }
  IEnumerator ScoreTimer() {
    j = score++;
    scoreText.text = j.ToString();
    yield return new WaitForSeconds(1f);
    StartCoroutine(ScoreTimer());
    }
}
