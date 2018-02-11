using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEgg : MonoBehaviour
{

    private SoundManager sm;

    // Spawner stuff
    private GameObject birbSpawner;
    private SpawnerController sc;

    // Birb's stuff
    [SerializeField] private GameObject birb;
    private PlayerController pc;
    private StatsController stats;
    private Animator anim;

    // Egg's
    private PhysicsObject po;

    [SerializeField] private Vector2 initNudge;
    private float blastModifier = 12.5f;

    private void Start()
    {

        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        birbSpawner = GameObject.Find("BirbSpawner");
        sc = birbSpawner.GetComponent<SpawnerController>();
        birb = sc.getBirb();

        pc = birb.GetComponent<PlayerController>();
        stats = birb.GetComponent<StatsController>();
        po = GetComponent<PhysicsObject>();
        anim = GetComponent<Animator>();
        
        stats.setCurrentGrav("egg");
        stats.setMoveable(true);
        MyAddForce(initNudge);
        pc.eggsOut++;
    }

    public void Explode(string type)
    {
        if (type == "live")
        {
            // Blast calculations
            Vector2 distance = birb.transform.position - transform.position;
            Vector2 blast = distance.normalized;
            blast *= blastModifier;
            pc.MyAddForce(blast);
            stats.setMoveable(false);
            stats.setCurrentGrav("normal");
        }
        sm.PlaySound("egg_sound");
        pc.eggsOut--;
        StartCoroutine(DoAnimation());
        
    }

    IEnumerator DoAnimation()
    {
        anim.Play("eggsplosion");
        yield return new WaitForSeconds(0.25f);
        Destroy(this.gameObject);
    }

    private void MyAddForce(Vector2 force)
    {
        po.velocityX = force.x;
        po.velocity.y = force.y;
    }

}