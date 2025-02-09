using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goo : MonoBehaviour
{
    [SerializeField] float slow;
    [SerializeField] GameObject sfx;
    MovePlayer player;

    float realSpeedPlayer;
    bool inMove;

    private void Update()
    {
        if (player != null)
        {
            inMove = player.GetComponent<MovePlayer>().IsMove;

            if (inMove)
            {
                sfx.SetActive(true);
            }

            if (!inMove)
            {
                sfx.SetActive(false);
            }
        }
        else
        {
            inMove = false;
            sfx.SetActive(false);
        }

        if (player != null)
        {
            player.InFloor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<MovePlayer>();
            player.InGram = true;
            realSpeedPlayer = player.Speed;
            player.Speed = slow;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.InGram = false;
            player.Speed = realSpeedPlayer;
            player = null;
        }
    }
}
