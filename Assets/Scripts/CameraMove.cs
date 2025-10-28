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

    public Vector3 camVelocity = new Vector3(0,0.2f,0);
    public Vector3 playerVelocity = new Vector3(2,0,0);

    void Start()
    {
        playerScript = player.GetComponent<PlayerMovement>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            coroutine = MoveCameraTop(0.8f);
            StartCoroutine(coroutine);
            sideWalls.SetActive(false);
            topWalls.SetActive(true);
            playerScript.topDown = true;
        }

        if (Input.GetKey(KeyCode.P))
        {
            coroutine = MoveCameraSide(0.8f);
            StartCoroutine(coroutine);
            sideWalls.SetActive(true);
            topWalls.SetActive(false);
            playerScript.topDown = false;
        }
    }

    private IEnumerator MoveCameraSide(float waitTime)
    {
        float timer = 0;
        while (timer < waitTime)
        {
            player.transform.position = Vector3.SmoothDamp(player.transform.position, new Vector3(-7.5f, 0, 2), ref playerVelocity, 0.5f);
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, new Vector3(0, 0, 0), ref camVelocity, 1f);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime/2f);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    
    private IEnumerator MoveCameraTop(float waitTime)
    {
        float timer = 0;
        while (timer < waitTime)
        {
            player.transform.position = Vector3.SmoothDamp(player.transform.position, new Vector3(-3.5f, 0, 0), ref playerVelocity, 0.5f);
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, new Vector3(0, 5, 0), ref camVelocity, 1f);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(90, 90, 0), Time.deltaTime/2f);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
