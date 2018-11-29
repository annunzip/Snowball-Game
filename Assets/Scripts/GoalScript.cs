using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GoalScript : MonoBehaviour {

    public GameObject goal;

    public Text scoreText;
    public int cur_score;
    public int max_score;

    public Camera winCam;
    public Camera loseCam;

    private GameObject fpsController;

	// Use this for initialization
	void Start () {
        cur_score = 0;
        UpdateScore();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        fpsController = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (cur_score == max_score)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            loseCam.enabled = false;
            winCam.enabled = true;
            Destroy(fpsController);
        }
	}

    public void AddScore(int newScoreValue)
    {
        cur_score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + cur_score + "/" + max_score;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
