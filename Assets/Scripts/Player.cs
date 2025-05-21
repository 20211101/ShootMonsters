using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ��ġ �̵�
    Vector3[] linePosition = new Vector3[3]
    {
        new Vector3(-3, 1, -15),    // 0
        new Vector3(0, 1, -15),     // 1
        new Vector3(3, 1, -15)      // 2
    };
    int playerLine = 1;

    // �Ѿ� �߻�
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
            // �������� �̵�
            if (playerLine == 0) // 1, 2
                return;
            playerLine -= 1;
            transform.position = linePosition[playerLine];
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            // ���������� �̵�
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

