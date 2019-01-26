using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class alternateScript : MonoBehaviour
{
    private bool enter = false;
    public int nbInput = 10;
    private bool alternative = true;
    private int playerId;
    private Player player;
    private SpriteRenderer sprite;
    public Sprite sprite01;
    public Sprite sprite02;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (alternative)
            {
                if (player.GetButtonDown("ButtonX"))
                {
                    nbInput--;
                    Debug.Log(nbInput);
                    alternative = false;
                    sprite.sprite = sprite02;
                }
            }
            else
            {
                if (player.GetButtonDown("ButtonY"))
                {
                    nbInput--;
                    Debug.Log(nbInput);
                    alternative = true;
                    sprite.sprite = sprite01;
                }
            }

        }
        if (nbInput <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        enter = true;
        if (other.gameObject.CompareTag("Player01"))
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


}
