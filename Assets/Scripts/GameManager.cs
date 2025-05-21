using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;

    public EnemySpawner enemySpawner;
    public Player player;

    float gameOverTime = 20f;

    void Update()
    {
        if (isGameOver) return;


        player.UpdatePlayer();
        enemySpawner.UpdateSpawner();

        gameOverTime -= Time.deltaTime;
        if (gameOverTime < 0)
            GameOver();
    }

    private void GameOver()
    {
        isGameOver = true;
        enemySpawner.DestroyAllMonsters();
        Debug.Log("플레이어 승리~!");
    }
}
