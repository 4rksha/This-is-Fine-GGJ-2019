using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public int playerId = 0;
    private float vertical;
    public float speed = 5f;
    Rigidbody2D rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        vertical = player.GetAxis("Move horizontal") * Time.deltaTime * 50f * speed;
        rb.MovePosition(rb.position + new Vector2(vertical, 0) * Time.fixedDeltaTime);
    }
}
