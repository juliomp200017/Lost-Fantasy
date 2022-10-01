using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongMetalTrap : MonoBehaviour
{
    Animator _animator;
    private Transform attackpoint;
    public float attackspace = 0.5f;
    public LayerMask playerlayer;
    public int attackpower = 20;
    public float attackrange = 0.1f;
    public float attackrate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        attackpoint = GetComponent<Transform>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetTrigger("activate");
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, playerlayer);

        foreach (Collider2D enemy in hitenemies)
        {

            enemy.GetComponent<PlayerDie>().takedamage(attackpower);
        }
    }
}
