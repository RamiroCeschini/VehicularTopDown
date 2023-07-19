using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerLife : MonoBehaviour, IDamagable
{
    [SerializeField] private float playerLife;
    [SerializeField] private float maxPlayerLife;
    [SerializeField] private bool isEnemy;
    public bool canBeDamaged;
    private UIController controller;
    private EnemyCounter enemyCounter;

    private void Awake()
    {
        Playerlife = maxPlayerLife;
    }
    private void Start()
    {

        canBeDamaged = true;
        controller = GameObject.FindWithTag("UIController").GetComponent<UIController>();
        enemyCounter = GameObject.FindWithTag("UIController").GetComponent<EnemyCounter>();
    }
    public float Playerlife 
    { 
        get { return playerLife; } 
        set 
        {
            if ( value > 0 && value < maxPlayerLife) 
            {
                playerLife = value; 
            }
            else if (value >= maxPlayerLife)
            {
                playerLife = maxPlayerLife;
            }

            else 
            {
                playerLife = 0;
                if (isEnemy) 
                {
                    enemyCounter.KillEnemy();
                    Destroy(gameObject); 
                }

                else {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("Defeat");
                }
            }
                 
        }
    }

    public void TakeDamage(float damage)
    {

        if (canBeDamaged == true && !isEnemy)
        {
            if (Playerlife > 0)
            {
                Playerlife -= damage;
                controller.UpdateLife(controller.playerLifeBar,Playerlife, maxPlayerLife);
                canBeDamaged = false;
                controller.ChangeOpacity(true,controller.inmunityRender);
                Invoke("BoolChange", 3f);
            }

        }

        else if (isEnemy)
        {
            Playerlife -= damage;
            controller.UpdateLife(controller.enemyLifeBar, Playerlife, maxPlayerLife);
        }
    }



    private void BoolChange()
    {
        canBeDamaged = true;
        controller.ChangeOpacity(false, controller.inmunityRender);
    }

}
