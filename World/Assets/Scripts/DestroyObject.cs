using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
   private void OnTriggerEnter(Collider other) {

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
}
