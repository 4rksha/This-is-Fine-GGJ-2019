﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CharacterAnim : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentsInChildren<Animator>()[0];
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentsInChildren<SpriteRenderer>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerController>().player.GetAxis("Move horizontal") != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (GetComponent<PlayerController>().player.GetAxis("Move horizontal") < 0)
        {
            sprite.flipX = true;
        }
        else if (GetComponent<PlayerController>().player.GetAxis("Move horizontal") > 0)
        {
            sprite.flipX = false;
        }
    }
}
