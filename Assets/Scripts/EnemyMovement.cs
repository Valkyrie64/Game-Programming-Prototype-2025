using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StopEnemy")
        {
            speed = 0f;
        }
    }
}
