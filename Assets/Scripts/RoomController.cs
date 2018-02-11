using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {

    [SerializeField] private int eggCount;

    [SerializeField] private GameObject birb;
    [SerializeField] private SpawnerController spawner;
    [SerializeField] private StatsController birbStats;

	void Start () {
        spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
        if (spawner)
            birb = spawner.getBirb();
        if (birb)
            birbStats = birb.GetComponent<StatsController>();
        if (birbStats)
            birbStats.setEggMax(eggCount);
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

	}

    private void restartLevel()
    {
        spawner.respawnBirb();
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

}
