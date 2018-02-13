using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenChanger : MonoBehaviour {

    protected TimerController tc;
    protected GameObject timerObj;
    

    void Start()
    {
        timerObj = GameObject.Find("Timer");
        tc = timerObj.transform.GetComponent<TimerController>();
        tc.Finish();
    } 
    
  


    // Update is called once per frame
    void Update () {
        try
        {
            timerObj = GameObject.Find("Timer");
            tc = timerObj.GetComponent<TimerController>();
            tc.Finish();
        } catch
        {
            Debug.Log(timerObj);
            if (timerObj == null)
                Debug.Log("greg");
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
