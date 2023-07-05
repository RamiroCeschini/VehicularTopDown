using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletToSpawn;
    //public ParticleSystem gunSmoke;
    public float coolDownTime = 1f;
    private bool coolDown = false;

    private void Start()
    {
        spawnPoint = GameObject.FindWithTag("BulletSpawnPoint").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDown == false)
        {
            Shoot();
            Invoke("ResetCoolDown", coolDownTime);

        }
    }

    private void Shoot()
    {
        coolDown = true;
        Instantiate(bulletToSpawn, spawnPoint.position, spawnPoint.rotation);
     //   Instantiate(gunSmoke, spawnPoint.position, spawnPoint.rotation);

    }

    private void ResetCoolDown()
    {
        coolDown = false;
    }

}
