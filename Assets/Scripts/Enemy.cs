using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    private int currenthealth;
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    public void takedamage(int damage)
    {
        currenthealth -= damage;

        _animator.SetTrigger("takehit");

        if(currenthealth <= 0)
        {
            die();
        }

    }
    void die()
    {
        _animator.SetBool("dead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
