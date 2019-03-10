using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class Leaderboard : MonoBehaviour
{
    public Transform checkScoreboardButton;
    // Start is called before the first frame update
    void Start()
    {
        // Authenticate
        Social.localUser.Authenticate (ProcessAuthentication);
    }

    void Awake() {
        //checkScoreboardButton.GetComponent<Button>().onClick.AddListener(() => { Social.ShowLeaderboardUI(); });
    }

    void ProcessAuthentication (bool success) {
    if (success) {
        Debug.Log ("Authenticated, checking achievements");
    } else {
	Debug.Log ("Failed to authenticate");
        }     
    }

    void ReportScore (long score, string leaderboardID) {
    Debug.Log ("Reporting score " + score + " on leaderboard " + leaderboardID);
    Social.ReportScore (score, leaderboardID, success => {
	Debug.Log(success ? "Reported score successfully" : "Failed to report score");
    });
}

public void Press() {
    //checkScoreboardButton.GetComponent<Button>().onClick.AddListener(() => { Social.ShowLeaderboardUI(); });
    Social.ShowLeaderboardUI();
}


}
