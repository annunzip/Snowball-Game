using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {
    public GameObject bullet_prefab;
    float bulletImpulse = 20f;
    public GameObject empty; 
    // Use this for initialization
    void Start () {
        InvokeRepeating("Break", 3.0f, 2f);
    }
	
	// Update is called once per frame
	void Break () {
         
    GameObject thebullet = (GameObject)Instantiate(bullet_prefab, empty.transform.position + empty.transform.forward, empty.transform.rotation);
			thebullet.GetComponent<Rigidbody>().AddForce( empty.transform.forward * bulletImpulse, ForceMode.Impulse);
        
	}
    void Update()
    {
        
    }
}
