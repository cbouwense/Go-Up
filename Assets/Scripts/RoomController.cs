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
        birb = spawner.getBirb();
        birbStats = birb.GetComponent<StatsController>();

        birbStats.setEggMax(eggCount);
	}
	
	void Update () {
		
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

}
