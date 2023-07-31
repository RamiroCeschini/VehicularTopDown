using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public Text countText;
    private int enemyCount;
    private int totalEnemies;
    public bool enemiesEliminated = false;

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Count();
        enemyCount = -1;
        KillEnemy();
    }

    public void KillEnemy()
    {
        enemyCount++;
        countText.text = "Enemies " + enemyCount + "/" + totalEnemies;
        CheckCount();
    }

    private void CheckCount()
    {
        if (enemyCount == totalEnemies)
        {
            Cursor.lockState = CursorLockMode.None;
            Invoke("WinScene", 2f);
        }
    }

    private void WinScene()
    {

        SceneManager.LoadScene("Win");
    }
}
