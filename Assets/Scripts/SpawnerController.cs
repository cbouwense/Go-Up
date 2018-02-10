using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject birbPrefab;
    [SerializeField] private GameObject birb;

    void Start()
    {
        spawnBirb();
    }

    // Returns reference to spawned birb
    private GameObject spawnBirb()
    {
        // TODO: animation hook here? 

        birb = Instantiate(birbPrefab, transform.position, new Quaternion());
        return birb;
    }

    private void despawnBirb()
    {
        // TODO: animation hook here

        Destroy(birb);
    }

    // Returns reference to spawned birb
    public GameObject respawnBirb()
    {
        despawnBirb();
        return spawnBirb();
    }

    // Returns reference to birb
    public GameObject getBirb()
    {
        return birb;
    }

}
