using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    Transform player;

    [SerializeField] GameController gameController;
    [SerializeField] float smoothSpeed = 0.5f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] Vector3 offset;

    public Transform Player { get => player; set => player = value; }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * slowSpeed);
            transform.position = smoothedPosition;
        }
    }

    public void ResetCam()
    {
        gameObject.transform.position = new Vector3(0, 0, -10);
    }
}
