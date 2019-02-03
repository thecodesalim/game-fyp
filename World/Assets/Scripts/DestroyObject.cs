using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    void Start() {
        //Score Score = GetComponent<Score>();
    }

    void Update() {
        //StartWave();  
    }
    void OnTriggerEnter(Collider other) {

       if(other.tag == "Finish"){
           print("collided");
           Destroy(this.gameObject);
           Destroy(other.gameObject);
       }
       else {        
           print("destroy");
           Destroy(this.gameObject);
       }  
       
   }

   void StartWave() {
       
       //GameObject[] spawnedBuildings = GetComponent<SpawnBuilding>().building;
       GameObject[] b = GameObject.FindGameObjectsWithTag("Finish");
       //Score s = cam.GetComponent<Score>();
       if(GameObject.Find("TextMeshPro Text").GetComponent<Score>().j > 20) {
           for (int i = 0; i < b.Length; i++) {
               Destroy(b[i], 0.5f);
           }
       }
    }
}
