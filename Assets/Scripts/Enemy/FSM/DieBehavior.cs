using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DieBehavior : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("Dead");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyHealthHandler enemyHealthHandler = animator.GetComponent<EnemyHealthHandler>();
        if (enemyHealthHandler != null)
        {
            enemyHealthHandler.OnDeathAnimationComplete();
        }
    }
}