using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 위치 이동
    Vector3[] linePosition = new Vector3[3]
    {
        new Vector3(-3, 1, -15),    // 0
        new Vector3(0, 1, -15),     // 1
        new Vector3(3, 1, -15)      // 2
    };
    int playerLine = 1;

    // 총알 발사
    public GameObject bulletObj;
    float shootTime = 1f;
    float curTime = 0f;

    public void UpdatePlayer()
    {
        PlayerMovement();
        PlayerShooting();
    }

    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            // 왼쪽으로 이동
            if (playerLine == 0) // 1, 2
                return;
            playerLine -= 1;
            transform.position = linePosition[playerLine];
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            // 오른쪽으로 이동
            if (playerLine == 2) // 0, 1
                return;
            playerLine += 1;
            transform.position = linePosition[playerLine];
        }
    }
    private void PlayerShooting()
    {
        curTime += Time.deltaTime;
        if (curTime > shootTime)
        {
            Instantiate(bulletObj, transform.position, Quaternion.identity);
            curTime -= shootTime;
        }
    }
}

