using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    public Text timerText;
    private float startTime;
    private bool finished = false;
    public float finishedTime = 0f;

   
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        startTime = Time.time;
        GameObject[] timers = GameObject.FindGameObjectsWithTag("Timer");
        foreach (GameObject g in timers)
        {
            if (g != this.gameObject)
            {
                GameObject.Destroy(this.gameObject);
            }
        }

        PlayerPrefs.SetInt("canSetLeaderboard", 1);
    }

    // Update is called once per frame
    void Update () {

        if (finished)
            return;

        float t = Time.time - startTime;
        finishedTime = t;

        string minutes = ((int) t / 60).ToString();
        if ((int) t / 60 < 10)
        {
            minutes = "0" + minutes;
        }
        string seconds = (t % 60).ToString("f2");
        if (t % 60 < 10)
            seconds = "0" + seconds;

        timerText.text = minutes + ":" + seconds;
	}

    public void Finish()
    {
        finished = true;
        timerText.color = Color.red;
    }
 
}
