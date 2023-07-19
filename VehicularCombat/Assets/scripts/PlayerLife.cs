using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamagable
{
    [SerializeField] private float playerLife;
    [SerializeField] private bool isEnemy;


    public float Playerlife 
    { 
        get { return playerLife; } 
        set 
        {
            if ( value > 0) 
            {
                playerLife = value; 
            }
            else 
            {
                playerLife = 0;
                if (isEnemy) { Destroy(gameObject); }
                else { Debug.Log("Moriste"); }
            }
                 
        }
    }

    public void TakeDamage(float damage)
    {
        Playerlife -= damage;
    }
}
