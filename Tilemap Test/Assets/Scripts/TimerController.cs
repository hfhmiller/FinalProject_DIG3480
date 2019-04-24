using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    private float timer;
    public Text timerText;


	// Use this for initialization
	void Start () {
        timer = 30;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        timerText.text = "Time:" + timer;

        if (timer <= 0)
        {
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
        }
	}
}
