using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float speed = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;

        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            other.GetComponent<Monster>().Dead();
            Destroy(gameObject);
        }
    }
}
