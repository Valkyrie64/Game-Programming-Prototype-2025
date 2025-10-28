using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public GameObject bullet;
    public Transform barrel;
    public bool topDown;

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
    }
}
