using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float speed;
    public float jumpForce;

    [Header("Components")]
    public Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space)) {
            TryJump();
        }
        
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = (transform.forward * z + transform.right * x) * speed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }


    private void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.5f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
