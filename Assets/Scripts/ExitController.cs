using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

    protected TimerController tc;
    protected GameObject timerObj;

    private void Start()
    {
        timerObj = GameObject.Find("Timer");
        Destroy(timerObj);
    }

    // Update is called once per frame
    void Update () {
        if (/*SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start") &&*/ Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }
    }
}
