using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEgg : MonoBehaviour
{
    // Birb's stuff
    private GameObject birb;
    private PlayerController pc;
    private StatsController stats;

    // Egg's
    private PhysicsObject po;

    [SerializeField] private Vector2 initNudge;
    private float blastModifier = 12.5f;

    private void Start()
    {
        birb = GameObject.Find("Birb");

        pc = birb.GetComponent<PlayerController>();
        stats = birb.GetComponent<StatsController>();
        po = GetComponent<PhysicsObject>();
        
        stats.setCurrentGrav("egg");
        stats.setMoveable(true);
        MyAddForce(initNudge);
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
        
        // TODO: blast animation here

        Destroy(this.gameObject);
    }

    private void MyAddForce(Vector2 force)
    {
        po.velocityX = force.x;
        po.velocity.y = force.y;
    }

}