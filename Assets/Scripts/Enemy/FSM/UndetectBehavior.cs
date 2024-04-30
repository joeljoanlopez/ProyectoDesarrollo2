using UnityEngine;

public class UndetectBehavior : StateMachineBehaviour
{
    public float _undetectTime = 1f;
    private EnemyAIController _AI;
    private float _timer;
    private Vector3 _direction;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _AI = animator.GetComponent<EnemyAIController>();
        _timer = _undetectTime;
        _direction = _AI.PlayerDirection();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Check Triggers
        if (_timer <= 0)
            animator.SetTrigger("Patrol");

        // Do stuff
        _timer -= Time.deltaTime;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, animator.transform.position + _direction, _AI._speed * Time.deltaTime);
    }
}