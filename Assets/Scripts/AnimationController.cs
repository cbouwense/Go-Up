using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private SpawnerController spawner;
    private GameObject birb;
    private Animator anim;
    string[] states = { "idle", "grounded", "moving", "falling", "layEgg" };

    private void Start()
    {
        spawner = GameObject.Find("BirbSpawner").GetComponent<SpawnerController>();
        birb = spawner.getBirb();
        anim = birb.GetComponent<Animator>();

        resetAnim();
    }

    public void changeAnim(string state)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (state == states[i])
            {
                anim.SetBool(states[i], true);
            }
        }
    }

    public void resetAnim()
    {
        for (int i = 0; i < states.Length; i++)
        {
            anim.SetBool(states[i], false);
        }
    }


}
