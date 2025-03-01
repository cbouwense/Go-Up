using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip runSound, jumpSound, eggSound, nextLevelSound, pickupSound;
    static AudioSource audioSrc;
    private float walkTimer, jumpTimer, eggTimer, nextLevelTimer, pickupTimer;

    void Start()
    {

        runSound = Resources.Load<AudioClip>("run_sound");
        jumpSound = Resources.Load<AudioClip>("jump_sound");
        eggSound = Resources.Load<AudioClip>("egg_sound");
        nextLevelSound = Resources.Load<AudioClip>("next_level_sound");
        pickupSound = Resources.Load<AudioClip>("pickup_sound");

        audioSrc = gameObject.GetComponent<AudioSource>();

        walkTimer = 0.0f;
        jumpTimer = 0.0f;
        eggTimer = 0.0f;
        nextLevelTimer = 0.0f;
        pickupTimer = 0.0f;

    }

    void Update()
    {
        if (walkTimer > 0)
            walkTimer -= Time.deltaTime;
        if (jumpTimer > 0)
            jumpTimer -= Time.deltaTime;
        if (eggTimer > 0)
            eggTimer -= Time.deltaTime;
        if (nextLevelTimer > 0)
            nextLevelTimer -= Time.deltaTime;
        if (pickupTimer > 0)
            pickupTimer -= Time.deltaTime;
    }

    public void PlaySound(string clip)
    {
        audioSrc.volume = 0.5f;
        switch (clip)
        {
            case "run_sound":
                if (walkTimer <= 0)
                {
                    audioSrc.PlayOneShot(runSound);
                    walkTimer = 0.35f;
                }
                break;

            case "jump_sound":
                if (jumpTimer <= 0)
                {
                    audioSrc.PlayOneShot(jumpSound);
                    jumpTimer = 0.1f;
                }
                break;

            case "egg_sound":
                if (eggTimer <= 0)
                {
                    audioSrc.PlayOneShot(eggSound);
                    eggTimer = 0.35f;
                }
                break;

            case "pickup_sound":
                if (pickupTimer <= 0)
                {
                    audioSrc.PlayOneShot(pickupSound);
                    pickupTimer = 0.1f;
                }
                break;

            case "next_level_sound":
                if (nextLevelTimer <= 0)
                {
                    audioSrc.PlayOneShot(nextLevelSound);
                    nextLevelTimer = 0.1f;
                }
                
                break;

            default:
                Debug.Log("Invalid sound request!");
                break;
        }
    }
}
