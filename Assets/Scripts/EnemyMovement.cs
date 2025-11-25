using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 8f;
	private GameObject spawner;
    public SpawnerMovement spawnerScript;
    public CameraMove cameraScript;
    public GameObject bullet;

    private float rand;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.Find("EnemySpawner");
        spawnerScript = spawner.GetComponent<SpawnerMovement>();
        var cameraGO = GameObject.Find("CameraMover");
        cameraScript = cameraGO.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
        timer += Time.deltaTime;
        if (timer >= rand)
        {
            rand = Random.Range(1, 2.5f);
            timer = 0;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StopEnemy")
        {
            speed = 0f;
        }
    }

    void OnDisable()
    {
        cameraScript.enemiesKilled++;
        spawnerScript.enemyList.Remove(gameObject);
    }
}
