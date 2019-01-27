using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class spamScriptV2 : MonoBehaviour
{
    private bool enter;
    public int nbInput = 10;
    private int playerId;
    Player player;
    private SpriteRenderer sprite;
    public int damage = 2;
    private SpriteRenderer spriteAsset;
    public Sprite spriteAsset01;
    public Sprite spriteAsset02;

    // Start is called before the first frame update
    void Start()
    {
        spriteAsset = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteAsset.sprite = spriteAsset01;
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        StartCoroutine("BlinkSprite");
        StartCoroutine("ChangeSprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (player.GetButtonDown("ButtonB"))
            {
                nbInput--;
                Debug.Log(nbInput);
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

    IEnumerator BlinkSprite()
    {
        while (true)
        {

            if (enter)
            {
                sprite.enabled = true;
                yield return new WaitForSeconds(0.2f);
                sprite.enabled = false;
            }
            yield return new WaitForSeconds(0.2f);

        }
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
