using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    private AudioSource tickSource;
    public GameObject planet;
    void Start() {
        //Score Score = GetComponent<Score>();
        planet = GameObject.Find("Planet 12");
    }

    void Update() {
        tickSource = GetComponent<AudioSource>();
        //StartWave();  
    }
    void OnTriggerEnter(Collider other)  {

        tickSource.Play();
        print(tickSource);

       if(other.tag == "Finish"){
           Destroy(this.gameObject);
           Destroy(other.gameObject, 2f);
       }
       else {        
           Vector3 spawnPosition = Random.onUnitSphere * (planet.GetComponent<SphereCollider>().radius + 15f * 0.5f) + planet.transform.position;
           //transform.parent = planet.transform;
           Destroy(this.gameObject, 2f);
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
