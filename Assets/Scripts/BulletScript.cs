using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;

    [SerializeField] MeshRenderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (bulletSpeed * Time.deltaTime));
        if (!rend.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
