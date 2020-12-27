using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpWhenJump : StateMachineBehaviour
{
    Transform player;
    bool up = true;
    bool down = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponentInParent<Transform>();
        up = true;
        down = false;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 newPos = player.position;
        newPos.y = 1.5f;
        player.position = newPos;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.position.y < 2.6f && up)
        {
            player.position += new Vector3(0, 3, 0) * Time.deltaTime;
        }
        else
        {
            up = false;
            down = true;
        }
        if (player.position.y > 1.5f && down)
        {
            player.position += new Vector3(0, -2, 0) * Time.deltaTime;
        }
    }
}
