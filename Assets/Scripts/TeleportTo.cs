using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TeleportTo : MonoBehaviour
{
    public GameObject LinkedDoor;
    public Vector3 Offset = new Vector3(0,0,-1);
    private Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        int playerID = collision.gameObject.GetComponent<PlayerController>().playerId;
        player = ReInput.players.GetPlayer(playerID);
        if (player.GetButtonDown("ButtonA"))
        {
            collision.transform.position = LinkedDoor.transform.position + Offset;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<PlayerController>().DoorPos(LinkedDoor.transform.position + Offset);
    }
}
