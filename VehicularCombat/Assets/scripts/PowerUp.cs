using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject bulletPower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInChildren<IShooter>() != null)
        {
            collision.gameObject.GetComponentInChildren<IShooter>().ChangeBullet(bulletPower);
            Destroy(gameObject);
        }
    }
}
