using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] MovePlayer movePlayer;
    [SerializeField] SpriteRenderer spriteRender;

    // Update is called once per frame
    void Update()
    {
        AnimationController();
    }

    private void AnimationController()
    {
        if (movePlayer.Direction == 1)
        {
            anim.SetInteger("move", 1);
            spriteRender.flipX = false;
        }
        else if (movePlayer.Direction == -1)
        {
            anim.SetInteger("move", 1);
            spriteRender.flipX = true;
        }
        else
        {
            anim.SetInteger("move", 0);
        }

        if (movePlayer.IsJumping)
        {
            anim.SetBool("jump", true);
        }
        else if (movePlayer.InFloor || movePlayer.InGram)
        {
            anim.SetBool("jump", false);
        }
    }
}
