using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{
    [SerializeField] GameController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gem"))
        {
            controller.CountGem(1);

            if (controller.GetComponent<SpriteRenderer>() != null)
            {
                controller.GetComponent<SpriteRenderer>().enabled = false;
            }

            Destroy(collision.gameObject, 0.2f);
        }
    }
}
