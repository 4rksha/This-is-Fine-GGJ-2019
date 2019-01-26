using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class julScript : MonoBehaviour
{
    private Player player;
    private bool[] keys = new bool[3];
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("KeyJ"))
        {
            keys[0] = true;
        } else if(player.GetButtonDown("KeyU"))
        {
            if(keys[0])
            {
                keys[1] = true;
            }
        }
        else if (player.GetButtonDown("KeyL"))
        {
            if (keys[1])
            {
                keys[0] = false;
                keys[1] = false;
                audio.Play();
            }
        }
    }
}
