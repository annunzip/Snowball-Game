using UnityEngine;
using System.Collections;

public class BULLET_ThermalDetonator : MonoBehaviour {
	
	float lifespan = 2.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.tag=="Snowball")
        { 
		lifespan -= Time.deltaTime;
		
		if(lifespan <= 0) {
			Explode();
                }
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		
		if(collision.gameObject.tag == "Enemy") {
			Destroy(gameObject);	
            
            		}
	}
	
	void Explode() {
		
		Destroy(gameObject);
	}
}
