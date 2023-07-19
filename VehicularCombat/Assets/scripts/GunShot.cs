using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour, IShooter
{
    public Transform spawnPoint;
    public GameObject bulletBasic;
    public GameObject bulletToSpawn;
    public GameObject bulletParticle;
    public AudioClip shotSound;
    private UIController controller;


    public bool isEnemy = false;
    public Transform enemyTarget;
    public float shootDistance;

    public float coolDownTime = 1f;
    private bool coolDown = false;

    private void Start()
    {
        controller = GameObject.FindWithTag("UIController").GetComponent<UIController>();
        spawnPoint = transform.Find("SpawnPoint");
        bulletToSpawn = bulletBasic;   
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDown == false && !isEnemy)
        {
            Shoot();
            Invoke("ResetCoolDown", coolDownTime);
        }
        else if (isEnemy && !coolDown && Vector3.Distance((enemyTarget.transform.position), transform.position) < shootDistance) 
        {
            Shoot();
            Invoke("ResetCoolDown", coolDownTime);
        }

    }

    private void Shoot()
    {
        coolDown = true;
        Instantiate(bulletToSpawn, spawnPoint.position, spawnPoint.rotation);
        Instantiate(bulletParticle, spawnPoint.position, spawnPoint.rotation);
        AudioSource _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(shotSound);

    }

    public void ChangeBullet(GameObject newBulletPrefab)
    {
        bulletToSpawn = newBulletPrefab;
        controller.ChangeOpacity(true, controller.powerUpRender);
        if (bulletToSpawn != bulletBasic) { Invoke("ResetBullet", 7f); }
    }
    
    private void ResetBullet()
    {
        bulletToSpawn = bulletBasic;
        controller.ChangeOpacity(false, controller.powerUpRender);
    }

    private void ResetCoolDown()
    {
        coolDown = false;
    }

}
