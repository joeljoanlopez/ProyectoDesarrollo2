using System.Threading;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    public float _idleTime = 2f;
    private float _timer;
    private EnemyAIController _AI;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = _idleTime;
        _AI = animator.GetComponent<EnemyAIController>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_timer <= 0)
            animator.SetTrigger("Attack");
        if (_AI.Hiding)
            animator.SetTrigger("Undetect");
        if (_AI.Distance >= _AI._attackDistance)
            animator.SetTrigger("Chase");

        _timer -= Time.deltaTime;
    }
}