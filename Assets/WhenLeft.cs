using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenLeft : StateMachineBehaviour
{
    Transform player;
    float X;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponentInParent<Transform>();
        X = player.position.x - 2;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.position.x > X) 
        {
            player.position += new Vector3(-2, 0, 0) * Time.deltaTime;
        }
    }
}
