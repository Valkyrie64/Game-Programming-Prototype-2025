using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    public float speed;
    public GameObject enemyGO;
    private float timer;
    private float spawnTime = 0f;
    public List<GameObject> enemyList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
        timer += Time.deltaTime;
        if (timer >= spawnTime && enemyList.Count <= 4)
        {
            Instantiate(enemyGO, transform.position, Quaternion.identity);
            enemyList.Add(GameObject.FindGameObjectWithTag("Enemy"));
            spawnTime = UnityEngine.Random.Range(0.8f, 1.8f);
            timer = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            speed = speed * -1;
        }
    }
}
