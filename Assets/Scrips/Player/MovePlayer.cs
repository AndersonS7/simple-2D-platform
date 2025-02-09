using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MovePlayer : MonoBehaviour
{
    GameController gameController;

    [Header("Player ---")]
    [SerializeField] float speed;
    [SerializeField] float speedJump;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AnimManager anim;

    // jump
    [SerializeField] float jumpForce;
    [SerializeField] Vector2 gravity;
    [SerializeField] GameObject sfxJump;

    [Header("Colision ---")]
    [SerializeField] LayerMask layerFloor;
    [SerializeField] string movingPlatformsTag;
    [SerializeField] Vector2 size;
    [SerializeField] Vector2 offSet;

    //status the player
    float direction;
    bool isMove = false;
    bool inFloor = false;
    bool inGram = false;
    bool isJumping = false;
    float startSpeed;


    GameObject currentPlatform;

    public float Direction { get => direction; set => direction = value; }
    public bool IsMove { get => isMove; }
    public bool InFloor { get => inFloor; set => inFloor = value; }
    public bool IsJumping { get => isJumping; }
    public bool InGram { get => inGram; set => inGram = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
        {
            speed = speedJump;
        }
        else
        {
            speed = startSpeed;
        }

        if (!gameController.Paused)
        {
            if (!InFloor && (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f))
            {
                isJumping = true;
                sfxJump.SetActive(true);
            }
            else
            {
                isJumping = false;
            }

            if (inFloor)
            {
                sfxJump.SetActive(false);
            }

            Jump();
            FollowPlatform();
        }
    }

    void FixedUpdate()
    {
        if (!gameController.Paused)
        {
            Move();
            GroundCheck();
        }
    }

    private void Move()
    {
        Direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Direction * Speed, rb.velocity.y);

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
        if (inFloor && !inGram)
        {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        if (rb.velocity.y > 0)
        {
            if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f);
            }
        }

        //gravity
        if (rb.velocity.y < 0)
        {
            rb.velocity -= gravity * Time.deltaTime;
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
            if (!isMove && currentPlatform != null)
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
