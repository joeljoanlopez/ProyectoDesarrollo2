using System;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{
    private GameObject _player;
    private EnemyAttackHandler[] _attackHandler;
    private EnemyAIController _AI;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindWithTag("Player");
        _attackHandler = animator.GetComponentsInChildren<EnemyAttackHandler>();
        _AI = animator.GetComponent<EnemyAIController>();
        for (int i = 0; i < _attackHandler.Length; i++)
            _attackHandler[i].DoStrike();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetTrigger("Idle");
    }
}