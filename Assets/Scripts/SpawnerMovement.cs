using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    public float speed;
    public GameObject enemyGO;
    private float timer;
    private float spawnTime = 0f;
    public List<GameObject> enemyList;

    public bool sideOn;

    public CameraMove cameraScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sideOn)
        {
            case true:
                transform.Translate(Vector3.up * (speed * Time.deltaTime));
                break;
            case false:
                transform.Translate(Vector3.forward * (speed * Time.deltaTime));
                break;
        }
        timer += Time.deltaTime;
        if (timer >= spawnTime && enemyList.Count <= 4)
        {
            var enemyForList = Instantiate(enemyGO, transform.position, Quaternion.identity);
            enemyList.Add(enemyForList);
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
