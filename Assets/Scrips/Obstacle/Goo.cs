using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goo : MonoBehaviour
{
    float realSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            realSpeed = collision.GetComponent<MovePlayer>().speed;
            collision.GetComponent<MovePlayer>().speed = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<MovePlayer>().speed = realSpeed;
        }
    }
}
