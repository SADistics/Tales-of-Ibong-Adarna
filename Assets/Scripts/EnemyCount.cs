using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public int enemyCount;
    public Text enemyCountText;

    void Start()
    {
        enemyCountText = GameObject.Find("EnemyCount").GetComponent<Text>();
    }
    public void DecreaseEnemy()
    {
        enemyCount -= 1;
        if (enemyCount <= 0)
        {
            enemyCount = 0;
        }
        enemyCountText.text = enemyCount.ToString();
    }
}
