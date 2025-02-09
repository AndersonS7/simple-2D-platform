using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{
    [SerializeField] GameController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gem"))
        {
            controller.CountGem(1);

            if (collision.gameObject.GetComponent<Fx>() != null)
            {
                collision.gameObject.GetComponent<Fx>().ActiveFx();
            }
        }
    }
}
