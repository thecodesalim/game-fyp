using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    private AudioSource tickSource;
    public GameObject effect;
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
    }    void OnTriggerEnter(Collider other)  
    {
        tickSource.Play();

       if(other.tag == "Finish")
       {
           Time.timeScale = 0.5f;
           Instantiate(effect, other.gameObject.transform.position, Quaternion.identity );
           Destroy(this.gameObject);
           Destroy(other.gameObject);
           gameManager.EndGame();
           print("GAMEOVER SCREEN");
       }
       else 
       {        
           Destroy(this.gameObject, 2f);
       }  
   }
}
