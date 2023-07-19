using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float lifeHeal;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInChildren<IDamagable>() != null)
        {
            collision.gameObject.GetComponentInChildren<IDamagable>().TakeDamage(lifeHeal);
            Destroy(gameObject);
        }
    }
}
