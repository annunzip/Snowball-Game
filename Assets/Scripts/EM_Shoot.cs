using UnityEngine;
using System.Collections;

public class EM_Shoot : MonoBehaviour {

    float lifespan = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "EnemyFire")
        {
            lifespan -= Time.deltaTime;

            if (lifespan <= 0)
            {
                Explode();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }

    void Explode()
    {

        Destroy(gameObject);
    }
}