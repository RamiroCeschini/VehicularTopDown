using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrainComands : MonoBehaviour
{
    public float power = 15000f;


    private float forwardAmount;
    private float turnAmount;

    public Wheel[] wheels;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float GetSpeed()
    {
        return(rb.velocity.magnitude);
    }

    public void SetInputs(float foward, float turn)
    {
        forwardAmount = foward;
        turnAmount = turn;
    }
    private void FixedUpdate()
    {
        ProcessForces();
    }
    void ProcessForces()
    {
        foreach (Wheel w in wheels)
        {
            w.Steer(turnAmount);
            w.Accelerate(forwardAmount * power);
            w.UpdatePosition();
        }
    }
}
