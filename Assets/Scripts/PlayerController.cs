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
    Vector3 doorTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("ButtonA"))
        {
            Debug.Log(doorTarget.ToString());
            if(doorTarget != new Vector3())
            {
                Vector3 t = transform.position;
                transform.position = doorTarget;
                doorTarget = t;
            }
        }
    }

    void FixedUpdate()
    {
        vertical = player.GetAxis("Move horizontal") * Time.deltaTime * 50f * speed;
        rb.MovePosition(rb.position + new Vector2(vertical, 0) * Time.fixedDeltaTime);
    }
    public void DoorPos(Vector3 pos)
    {
        doorTarget = pos;
    }

    public Vector3 GetPos()
    {
        return doorTarget;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GetPos() != collision.gameObject.transform.position)
        {
            DoorPos(new Vector3());
        }
    }

}
