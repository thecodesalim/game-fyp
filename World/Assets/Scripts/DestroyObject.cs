using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    private AudioSource tickSource;
    public GameObject planet;
    GameManager gameManager;
    void Start() 
    {
        //Score Score = GetComponent<Score>();
        planet = GameObject.Find("Planet 12");
        gameManager =  GameObject.FindObjectOfType<GameManager>(); 
    }

    void Update() 
    {
        tickSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)  
    {

        //print("collison");

        tickSource.Play();
        //print(tickSource);

       if(other.tag == "Finish")
       {
           //print("Destroy " + gameManager.gameHasStarted);
           Destroy(this.gameObject);
           Destroy(other.gameObject, 2f);
           //gameManager.EndGame();
       }
       else 
       {        
           Destroy(this.gameObject, 2f);
       }  
       //gameManager.EndGame();
   }
}
