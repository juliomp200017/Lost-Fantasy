using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Movements : StateMachineBehaviour
{
    public float attackrange = 3f;
    public float speed = 2f;
    Transform player;
    Rigidbody2D _rigidbody2D;
    Boss1 Boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody2D = animator.GetComponent<Rigidbody2D>();
        Boss = animator.GetComponent<Boss1>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, _rigidbody2D.position.y);
        Vector2 newposition = Vector2.MoveTowards(_rigidbody2D.position, target, speed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(newposition);
        if (Vector2.Distance(player.position, _rigidbody2D.position) <= attackrange)
        {
            animator.SetTrigger("attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

}
