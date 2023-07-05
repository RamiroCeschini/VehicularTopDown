using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainController2 : MonoBehaviour
{
    public float power = 15000f;

    private float horInput;
    private float verInput;

     public Wheel[] wheels;

    public Rigidbody rb;
    public float currentVelocity;
    public int restartCounter;
    public float rayDistance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("ReadVelocity", 0f, 1f);
    }

    void Update() 
    {
        ProcessInput();
        Debug.DrawRay(gameObject.transform.position,- gameObject.transform.up * rayDistance, Color.red);
    }

    void FixedUpdate()
    {
        ProcessForces();
    }

    void ProcessInput()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }

    void ProcessForces()
    {
        foreach(Wheel w in wheels)
        {
            w.Steer(horInput);
            w.Accelerate(verInput * power);
            w.UpdatePosition();
        }
    }

    void ReadVelocity()
    {
        currentVelocity = rb.velocity.magnitude;
        RaycastHit hit;
      
        if (Physics.Raycast(gameObject.transform.position, - gameObject.transform.up, out hit, rayDistance, LayerMask.GetMask("Floor" )))
        {
          
        Debug.Log("Todo ok");
        restartCounter = 0;
           
        }
        else
        {
            restartCounter++;
            Debug.Log(restartCounter.ToString());
            if (restartCounter > 3)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        Debug.Log("Velocity is: " +  currentVelocity);
    }

}
