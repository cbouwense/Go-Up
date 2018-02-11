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
        spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
        if (spawner)
            birb = spawner.getBirb();
        if (birb)
            birbStats = birb.GetComponent<StatsController>();
        if (birbStats)
            birbStats.setEggMax(eggCount);

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        SetEggCounter();
    }
	
	void Update () {
		
        // Keep trying to get the ref if you dont have it
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

        //Load a scene by the name "SceneName" if you press the W key.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }

        SetEggCounter();

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
