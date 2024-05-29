using UnityEngine;

public class ChaseBehavior : StateMachineBehaviour
{
    private GameObject _player;
    private EnemyAIController _AI;

    AudioManager _audioManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindWithTag("Player");
        _AI = animator.GetComponent<EnemyAIController>();
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Check triggers
        if (_AI.Hiding)
            animator.SetTrigger("Undetect");
        if (_AI.Distance <= _AI._attackDistance)
            animator.SetTrigger("Attack");

        // Do stuff
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, _player.transform.position, _AI._speed * Time.deltaTime);
    }
}