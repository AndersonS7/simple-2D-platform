using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MovePlayer : MonoBehaviour
{
    [Header("Player ---")]
    public float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AnimManager anim;

    [Header("Colision ---")]
    [SerializeField] LayerMask layerFloor;
    [SerializeField] string movingPlatformsTag;
    [SerializeField] Vector2 size;
    [SerializeField] Vector2 offSet;

    //status the player
    float direction;
    bool isJump = false;
    bool isMove = false;
    bool inFloor = false;

    GameObject currentPlatform;

    public float Direction { get => direction; set => direction = value; }
    public bool IsJump { get => isJump; set => isJump = value; }
    public bool InFloor { get => inFloor; set => inFloor = value; }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && inFloor || Input.GetKeyDown(KeyCode.UpArrow) && inFloor)
        {
            isJump = true;
        }
        else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0 || Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f);
        }

        FollowPlatform();
    }

    void FixedUpdate()
    {
        Jump();
        Move();
        GroundCheck();
    }

    private void Move()
    {
        Direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Direction * speed, rb.velocity.y);

        if (Direction != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }

    private void Jump()
    {
        if (isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJump = false;
        }
    }

    private void GroundCheck()
    {
        Collider2D collider = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + offSet.x, gameObject.transform.position.y + offSet.y), size, 0f, layerFloor);

        // is touching the ground
        if (collider)
        {
            inFloor = true;
        }
        else
        {
            inFloor = false;
        }

        // is touching the platform
        if (collider != null)
        {
            // active follow platform
            if (movingPlatformsTag == "")
            {
                movingPlatformsTag = "Untagged";
                Debug.Log("The 'movingPlatformsTag' is empty, enter the name of the tag");
            }
            else
            {
                if (collider.gameObject.CompareTag(movingPlatformsTag) && movingPlatformsTag != "Untagged")
                {
                    currentPlatform = collider.gameObject;
                }
                else
                {
                    currentPlatform = null;
                }
            }
        }
        else
        {
            currentPlatform = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + offSet.x, gameObject.transform.position.y + offSet.y), size);
    }

    private void FollowPlatform()
    {
        if (currentPlatform != null)
        {
            if (!isJump && !isMove && currentPlatform != null)
            {
                transform.SetParent(currentPlatform.transform);
            }
            else
            {
                transform.SetParent(null);
            }
        }
        else
        {
            transform.SetParent(null);
        }
    }
}
