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
        

        if (!movePlayer.IsJump)
        {
            if (movePlayer.Direction == 1)
            {
                spriteRender.flipX = false;
                anim.SetInteger("move", 1);
            }
            else if (movePlayer.Direction == -1)
            {
                spriteRender.flipX = true;
                anim.SetInteger("move", 1);
            }
            else
            {
                anim.SetInteger("move", 0);
            }
        }
    }
}
