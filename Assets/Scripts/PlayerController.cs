using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float vertical;
    public float movementSpeed = 500f;
    public float speed = 5f;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        vertical = (Input.GetAxis ("Horizontal") * Time.deltaTime * movementSpeed) *10;
        rb.MovePosition(rb.position + new Vector2(vertical, 0) * Time.fixedDeltaTime);
    }
}
