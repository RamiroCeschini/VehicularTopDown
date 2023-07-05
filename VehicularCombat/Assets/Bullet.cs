using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(-bulletSpeed, 0f, 0f);
        Invoke("DestroyBullet", 4f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

 
}
