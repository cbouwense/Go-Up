using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickup : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D col)
    {
        SoundManager sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (col.tag == "Birb")
        {
            StatsController birbStats = col.gameObject.GetComponent<StatsController>();
            birbStats.setEggCurr(birbStats.getEggCurr() + 1);
            sm.PlaySound("pickup_sound");
            Destroy(this.gameObject);
        }

    }
}
