using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomController : MonoBehaviour {

    [SerializeField] private int eggCount;

    [SerializeField] private GameObject birb;
    [SerializeField] private SpawnerController spawner;
    [SerializeField] private StatsController birbStats;

    public Text countText;



    void Start () {

        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            try
            {
                spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
            }
            catch
            {
                Debug.Log("Spawner not found, will try again in Update()");
            }

            if (spawner)
                birb = spawner.getBirb();
            if (birb)
                birbStats = birb.GetComponent<StatsController>();
            if (birbStats)
                birbStats.setEggMax(eggCount);

            SetEggCounter();
        }

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        
    }
	
	void Update () {

        // If we're not in the main menu
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            // Keep trying to get the ref if you dont have it
            if (!spawner)
                spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
            if (!birb)
                birb = spawner.getBirb();
            if (!birbStats)
                birbStats = birb.GetComponent<StatsController>();
            if (birbStats)
                birbStats.setEggMax(eggCount);

            // Restart Input
            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Restarting level");
                restartLevel();
            }
            
            // Go to menu by pressing Esc
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Start");
            }
            
            SetEggCounter();
        }

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    void SetEggCounter()
    {
        if (countText && birbStats)
            countText.text = "Eggs Remaining: " + birbStats.getEggCurr();
    }
}
