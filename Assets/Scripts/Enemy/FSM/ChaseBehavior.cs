using UnityEngine;

public class ChaseBehavior : StateMachineBehaviour
{
    private GameObject _player;
    private EnemyAIController _AI;
    private SpriteRenderer _sprite;

    AudioManager _audioManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindWithTag("Player");
        _AI = animator.GetComponent<EnemyAIController>();
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _sprite = animator.GetComponent<SpriteRenderer>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Check triggers
        if (_AI.Hiding)
            animator.SetTrigger("Undetect");
        if (_AI.Distance <= _AI._attackDistance)
            animator.SetTrigger("Attack");

        // Do stuff
        _sprite.flipX = _player.transform.position.x > animator.transform.position.x;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, _player.transform.position, _AI._speed * Time.deltaTime);
    }
}