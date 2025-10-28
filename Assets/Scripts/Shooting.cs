using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
