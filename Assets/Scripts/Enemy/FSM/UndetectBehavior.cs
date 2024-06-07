using UnityEngine;

public class UndetectBehavior : StateMachineBehaviour
{
    public float _undetectTime = 1f;
    private EnemyAIController _AI;
    private float _timer;
    private Vector3 _direction;
    private SpriteRenderer _sprite;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _AI = animator.GetComponent<EnemyAIController>();
        _timer = _undetectTime;
        _direction = _AI.PlayerDirection();
        _sprite = animator.GetComponent<SpriteRenderer>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Check Triggers
        if (_timer <= 0)
            animator.SetTrigger("Patrol");

        // Do stuff
        Vector2 _target = animator.transform.position + _direction;
        _sprite.flipX = _target.x > animator.transform.position.x;

        _timer -= Time.deltaTime;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, animator.transform.position + _direction, _AI._speed * Time.deltaTime);
    }
}