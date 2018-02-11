using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
        if (/*SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start") &&*/ Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }
    }
}
