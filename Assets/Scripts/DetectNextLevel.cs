using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNextLevel : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D col)
    {
        RoomController roomController = FindObjectOfType<RoomController>(); //GameObject.Find("RoomManager").GetComponent<RoomController>();

        if (col.tag == "Birb")
        {
            roomController.nextLevel();
        }
    }

}
