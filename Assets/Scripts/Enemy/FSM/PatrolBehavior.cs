using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    private HearingDetector _detector;
    private PathFollower _pathFollower;
    private EnemyAIController _AI;
    private SpriteRenderer _sprite;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _AI = animator.GetComponent<EnemyAIController>();
        _detector = animator.GetComponent<HearingDetector>();
        _pathFollower = animator.GetComponent<PathFollower>();
        _sprite = animator.GetComponent<SpriteRenderer>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check state change triggers
        if (_detector.Detected && !_AI.Hiding)
            animator.SetTrigger("Chase");

        // Do update Stuff
        bool _flip = _pathFollower.GetNextTransform().position.x > animator.transform.position.x;
        _sprite.flipX = _flip;
        
        _pathFollower.Move();
        if (_pathFollower.ArrivedAtWP())
            _pathFollower.NextWP();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _pathFollower.NextWP();
    }
}
