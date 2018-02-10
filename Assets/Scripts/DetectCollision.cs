using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D col)
    {
        ExplodeEgg exp = GetComponent<ExplodeEgg>();
        if (col.name == "Birb")
            exp.Explode("live");
        else
            exp.Explode("dud");
    }

}
