using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float max_Health = 100f;
    public float cur_Health = 0f;
    public GameObject Healthbar;

    public Camera winCam;
    public Camera loseCam;

    // Use this for initialization
    void Start () {
        cur_Health = max_Health;
	}
	
	// Update is called once per frame
	void Update () {
        if (cur_Health == 0)
        {
            loseCam.enabled = true;
            winCam.enabled = false;
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "EnemyFire")
        {
            decreaseHealth();

        }

    }
    void decreaseHealth()
    {
        cur_Health -= 20f;
        float calc_Health = cur_Health / max_Health;
        setHealthBar(calc_Health);
    }

    public void setHealthBar(float myHealth)
    {
        Healthbar.transform.localScale = new Vector3(myHealth, Healthbar.transform.localScale.y, Healthbar.transform.localScale.z);
    }
}
