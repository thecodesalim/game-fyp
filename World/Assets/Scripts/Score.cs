using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
  public TextMeshProUGUI scoreText;
  private int score = 1;
  private int timer = 100;

    // Update is called once per frame
    void Update() {
        timer--;
        if(timer <= 0){
            int j = score++;
            scoreText.text = j.ToString();
            timer = 100;
        }   
    }
}
