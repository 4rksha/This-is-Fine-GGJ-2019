using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class alternateScriptV2 : MonoBehaviour
{
    private bool enter = false;
    public int nbInput = 10;
    private bool alternative = true;
    private int playerId;
    private Player player;
    private SpriteRenderer sprite;
    private SpriteRenderer spriteAsset;
    public Sprite spriteButton01;
    public Sprite spriteButton02;
    public Sprite spriteAsset01;
    public Sprite spriteAsset02;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteAsset = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        spriteAsset.sprite = spriteAsset01;
        StartCoroutine("ChangeSprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            sprite.enabled = true;
            if (alternative)
            {
                if (player.GetButtonDown("ButtonX"))
                {
                    nbInput--;
                    Debug.Log(nbInput);
                    alternative = false;
                    sprite.sprite = spriteButton02;
                }
            }
            else
            {
                if (player.GetButtonDown("ButtonY"))
                {
                    nbInput--;
                    Debug.Log(nbInput);
                    alternative = true;
                    sprite.sprite = spriteButton01;
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
        sprite.enabled = false;
    }

    IEnumerator ChangeSprite()
    {
        while (true)
        {
            spriteAsset.sprite = spriteAsset01;
            yield return new WaitForSeconds(0.2f);
            spriteAsset.sprite = spriteAsset02;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
