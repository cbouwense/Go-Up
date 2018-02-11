using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGreg : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D col)
    {
        //SpawnerController spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
        RoomController rc = GameObject.Find("RoomManager").GetComponent<RoomController>();

        if (col.tag == "Birb")
        {
            rc.restartLevel();
            //spawner.respawnBirb();
        }
    }

}
