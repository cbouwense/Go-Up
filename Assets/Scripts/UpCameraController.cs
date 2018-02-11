using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCameraController : MonoBehaviour {

    public GameObject player;
    public SpawnerController spawner;

    void Update()
    {
        if (!spawner)
            spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
        if (spawner && !player)
            player = spawner.getBirb();

        if (player)
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

    }

}
