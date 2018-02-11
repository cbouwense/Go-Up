using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickup : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "Birb")
        {
            StatsController birbStats = col.gameObject.GetComponent<StatsController>();
            if (birbStats.getEggCurr() < birbStats.getEggMax())
            {
                Debug.Log("beep");
                birbStats.setEggCurr(birbStats.getEggCurr() + 1);
            }
            Destroy(this.gameObject);
        }

    }
}
