using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody rb;
    float speed = 25f;
    bool alreadyHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -1) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameOverTrigger")
        {
            Debug.Log("GAME OVER");
            Dead();
        }
    }

    public void Dead()
    {
        if (alreadyHit) return;
        alreadyHit = true;
        EnemySpawner.Instance.DeleteEnemy(gameObject);
    }
}
