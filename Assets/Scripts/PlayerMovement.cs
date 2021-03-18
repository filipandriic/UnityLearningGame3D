using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewayForce = 500f;
    public float jumpForce = 500f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") )
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            if ((rb.position.y > 0.9f) && (rb.position.y < 1.1f))
                rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("l"))
        {
            FindObjectOfType<GameManager>().restartDelay = 0f;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.y < 0f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }    
    }
}
