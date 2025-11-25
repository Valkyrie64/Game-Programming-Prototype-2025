using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private bool forEnemies;
    [SerializeField] MeshRenderer rend;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private PlayerMovement playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (forEnemies)
        {
            transform.Translate(Vector3.left * (bulletSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector3.right * (bulletSpeed * Time.deltaTime));
        }
        if (!rend.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (forEnemies == false)
        {
            if (other.CompareTag("Enemy"))
            {
                playerScript.scoreNumber += 10;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
