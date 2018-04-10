using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            PlayerPrefs.SetFloat("leader1", -1);
            PlayerPrefs.SetFloat("leader2", -1);
            PlayerPrefs.SetFloat("leader3", -1);

            GameObject.Find("Leaderboard").GetComponent<UnityEngine.UI.Text>().text = "CLEARED LEADERBOARD";
        }
    }
}
