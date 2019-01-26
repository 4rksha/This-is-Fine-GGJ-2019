using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class spamScript : MonoBehaviour
{
    public bool enter = false;
    public int nbInput = 10;
    public int playerId;
    Player player;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine("BlinkSprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if ( player.GetButtonDown("SpamInput")) {
                nbInput--;
                Debug.Log(nbInput);
            }
        }
        if(nbInput <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        enter = true;
        if(other.gameObject.CompareTag("Player01"))
        {
            playerId = 0;
            player = ReInput.players.GetPlayer(playerId);
        }
        else
        {
            playerId = 1;
            player = ReInput.players.GetPlayer(playerId);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        enter = false;
    }

    IEnumerator BlinkSprite()
    {
        while(true)
        {
            sprite.enabled = true;
            yield return new WaitForSeconds(0.2f);
            sprite.enabled = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
