using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {
    Transform tr_Player;
    public float max_Health = 100f;
    public float cur_Health = 0f;
    public GameObject Healthbar;
    float f_RotSpeed = 5.0f;

    public int scoreValue;

    private GoalScript goalScript;

    // Use this for initialization
    void Start () {
        GameObject goalObject = GameObject.FindWithTag("Goal");
        if (goalObject != null)
        {
            goalScript = goalObject.GetComponent<GoalScript>();
        }
        if (goalObject == null)
        {
            Debug.Log("Can not find GoalScript script.");
        }
        cur_Health = max_Health;
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update()  {

        if (cur_Health == 0)
        {
            Destroy(gameObject);
            goalScript.AddScore(scoreValue);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag == "Snowball")
            {
                decreaseHealth();

            }
        
    }

    void decreaseHealth()
    {
        cur_Health -= 25f;
        float calc_Health = cur_Health / max_Health;
        setHealthBar(calc_Health);
    }

    public void setHealthBar(float myHealth)
    {
        Healthbar.transform.localScale = new Vector3 (myHealth, Healthbar.transform.localScale.y, Healthbar.transform.localScale.z);
    }
}
