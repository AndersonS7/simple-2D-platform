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
    [SerializeField] SpriteRenderer spriteRender;

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

    // status originais
    public float startSpeed;

    // adicoinar um deay no pulo depois, para o player conseguir pular da ponta da plataforma
    float countDelayJump = 0;
    float maxDelayJump = 1.5f;

    // others
    GameObject currentPlatform;

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationControl();

        if (Input.GetButtonDown("Jump") && inFloor)
        {
            isJump = true;
        }
        else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
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
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (direction != 0)
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

    private void AnimationControl()
    {
        // animation
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            spriteRender.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            spriteRender.flipX = true;
        }
    }
}
