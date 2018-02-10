using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour {

    [SerializeField] private int maxSpeed;
    [SerializeField] private int currentSpeed;
    [SerializeField] private int eggMax;
    [SerializeField] private int eggCurr;
    [SerializeField] private bool moveable;
    [SerializeField] private float currentGrav;

    public float jumpVelocity;
    public float fallMultiplier;

    public float eggJumpVelocity;
    public float eggFallMultiplier;
    public float eggHorizontalSpeed;

    void Start()
    {
        currentSpeed = maxSpeed;
        eggCurr = eggMax;
        moveable = true;
        currentGrav = fallMultiplier;
    }

    public int getMaxSpeed()
    {
        return maxSpeed;
    }
    public int getCurrentSpeed()
    {
        return currentSpeed;
    }
    public int getEggMax()
    {
        return eggMax;
    }
    public int getEggCurr()
    {
        return eggCurr;
    }
    public bool getMoveable()
    {
        return moveable;
    }
    public float getCurrentGrav()
    {
        return currentGrav;
    }

    public void setMaxSpeed(int maxSpeed)
    {
        this.maxSpeed = maxSpeed;
    }
    public void setCurrentSpeed(int currentSpeed)
    {
        this.currentSpeed = currentSpeed;
    }
    public void setEggMax(int eggMax)
    {
        this.eggMax = eggMax;
    }
    public void setEggCurr(int eggCurr)
    {
        this.eggCurr = eggCurr;
    }
    public void setMoveable(bool moveable)
    {
        this.moveable = moveable;
    }
    public void setCurrentGrav(string grav)
    {
        switch (grav)
        {
            case "normal":
                currentGrav = fallMultiplier;
                break;
            case "egg":
                currentGrav = eggFallMultiplier;
                break;
            default:
                Debug.Log("Invalid gravity value requested!");
                break;
        }
    }

}
