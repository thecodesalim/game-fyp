using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUI : MonoBehaviour {
    public GameObject planet;
    public GameObject asteroid;
    private LineRenderer line; 
    // Start is called before the first frame update
    void Start() {
        line= gameObject.AddComponent<LineRenderer>();
        line.SetWidth(.2f , .2f); 
    }

    // Update is called once per frame
    void Update() {
        //line.SetPosition(0, new Vector3(50, 50, 50));
        line.SetPosition(0, asteroid.transform.position);
        line.SetPosition(1, planet.transform.position);
    }
}
