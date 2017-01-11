using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Need this to test some things -Swan Chase-
public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical,0);

        rb.AddForce(movement * speed);
    }
}
