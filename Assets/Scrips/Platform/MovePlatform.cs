using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [Header("start config")]
    [SerializeField] bool move;

    [Header("Limit config ---")]
    [SerializeField] float speed = 5f;
    [SerializeField] float oneWayLimit = 5f;
    [SerializeField] float returnLimit = -5f;

    [Header("Axis config ---")]
    [SerializeField] bool axisY;

    int direction = 1;

    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (move)
        {
            if (!axisY)
            {
                transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

                if (transform.position.x >= (startPos.x + oneWayLimit))
                {
                    direction = -1;
                }

                else if (transform.position.x <= (startPos.x - returnLimit))
                {
                    direction = 1;
                }
            }
            else
            {
                transform.Translate(Vector3.up * direction * speed * Time.deltaTime);

                if (transform.position.y >= (startPos.y + oneWayLimit))
                {
                    direction = -1;
                }

                else if (transform.position.y <= (startPos.y - returnLimit))
                {
                    direction = 1;
                }
            }
        }
    }
}