using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;
    public GameObject bulletParticle;
    public float bulletDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(-bulletSpeed, 0f, 0f);
        Invoke("DestroyBullet", 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null) 
        {
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(bulletDamage);
        }
        Instantiate(bulletParticle, transform.position,transform.rotation);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (gameObject != null) 
        { 
            Destroy(gameObject);
        }
    }

 
}
