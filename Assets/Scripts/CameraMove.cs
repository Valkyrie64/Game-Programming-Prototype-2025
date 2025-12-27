using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    private IEnumerator coroutine;
    public Camera cam;
    public GameObject player;
    private PlayerMovement playerScript;
    public GameObject sideWalls;
    public GameObject topWalls;

    public Vector3 camVelocity = new Vector3(0, 0.5f, 0);
    public Vector3 playerVelocity = new Vector3(10, 0, 0);

    public GameObject topDownEnemies;
    public GameObject sideOnEnemies;

    public SpawnerMovement spawnerScript;

    public int enemiesKilled;
    public SpawnerMovement currentSpawner;
    void Start()
    {
        playerScript = player.GetComponent<PlayerMovement>();
        currentSpawner = sideOnEnemies.GetComponentInChildren<SpawnerMovement>();
    }

    void Update()
    {
        if (playerScript.topDown == false && enemiesKilled >= 5)
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Enemy")) Destroy(gameObject);
            currentSpawner.enemyList.Clear();
            enemiesKilled = 0;
            coroutine = MoveCameraTop(4f);
            StartCoroutine(coroutine);
            sideWalls.SetActive(false);
            topWalls.SetActive(true);
            playerScript.topDown = true;
            topDownEnemies.SetActive(true);
            sideOnEnemies.SetActive(false);
            currentSpawner = topDownEnemies.GetComponentInChildren<SpawnerMovement>();
        }

        if (playerScript.topDown == true && enemiesKilled >= 5)
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Enemy")) Destroy(gameObject);
            currentSpawner.enemyList.Clear();
            enemiesKilled = 0;
            coroutine = MoveCameraSide(4f);
            StartCoroutine(coroutine);
            sideWalls.SetActive(true);
            topWalls.SetActive(false);
            playerScript.topDown = false;
            topDownEnemies.SetActive(false);
            sideOnEnemies.SetActive(true);
            currentSpawner = sideOnEnemies.GetComponentInChildren<SpawnerMovement>();
        }
    }

    public IEnumerator MoveCameraSide(float waitTime)
    {
        float timer = 0;
        while (timer < waitTime)
        {
            player.transform.position = Vector3.SmoothDamp(player.transform.position, new Vector3(-7.5f, 0, 2),
                ref playerVelocity, 0.5f);
            cam.transform.position =
                Vector3.SmoothDamp(cam.transform.position, new Vector3(0, 0, 0), ref camVelocity, 1f);
            cam.transform.rotation =
                Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2f);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator MoveCameraTop(float waitTime)
    {
        float timer = 0;
        while (timer < waitTime)
        {
            player.transform.position = Vector3.SmoothDamp(player.transform.position, new Vector3(-3.5f, 0, 0),
                ref playerVelocity, 0.5f);
            cam.transform.position =
                Vector3.SmoothDamp(cam.transform.position, new Vector3(0, 5, 0), ref camVelocity, 1f);
            cam.transform.rotation =
                Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(90, 90, 0), Time.deltaTime * 2f);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
   
