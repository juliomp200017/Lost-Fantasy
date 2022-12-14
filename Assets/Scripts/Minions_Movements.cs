using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Movements : StateMachineBehaviour
{
    public float attackrange = 1f;
    public float speed = 1f;
    public float distance = 4f;
    Transform player;
    Rigidbody2D _rigidbody2D;
    Boss1 Boss;
    private Transform attackpointm;
    public float attackspace = 0.5f;
    public LayerMask playerlayer;
    public int attackpower = 5;
    public float attackrate = 5.0f;
    private float nextattacktime = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody2D = animator.GetComponent<Rigidbody2D>();
        Boss = animator.GetComponent<Boss1>();
        attackpointm = animator.GetComponent<Boss1>().attackpointm;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        if(Vector2.Distance(player.position, _rigidbody2D.position) <= distance)
        {
            animator.SetBool("running", true);
            Boss.LookAtPlayer();
            Vector2 target = new Vector2(player.position.x, _rigidbody2D.position.y);
            Vector2 newposition = Vector2.MoveTowards(_rigidbody2D.position, target, speed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(newposition);
        }else animator.SetBool("running", false);

        if (Vector2.Distance(player.position, _rigidbody2D.position) <= attackrange)
        {
            if (Time.time >= nextattacktime)
            {
                
                animator.SetTrigger("attack");
                Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpointm.position, attackrange, playerlayer);

                foreach (Collider2D enemy in hitenemies)
                {
                    enemy.GetComponent<PlayerDie>().takedamage(attackpower);
                }
                nextattacktime = Time.time + 1f / attackrate;
            }
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpointm == null)
            return;

        Gizmos.DrawWireSphere(attackpointm.position, attackrange);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

}
