using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public GameObject bullet;
    public Transform barrel;
    public bool topDown;
    public int health;
    public int scoreNumber;
    public GameObject scoreGO;
    public TextMeshProUGUI scoreText;
    public GameObject restartButton;

    void Start()
    {
        scoreText = scoreGO.GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        var moveH = Input.GetAxisRaw("Horizontal");
        var moveV = Input.GetAxisRaw("Vertical");
        if (!topDown)
        {
            rb.linearVelocity = new Vector3(moveH * speed, moveV * speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector3(moveV * speed, 0, -moveH * speed);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bullet, barrel.position, Quaternion.identity);
        }
        
        scoreText.text = $"Score: {scoreNumber}";

        if (health <= 0)
        {
            restartButton.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
