using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DieBehavior : StateMachineBehaviour
{
    private float _timer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("Dead");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}