using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moves : MonoBehaviour
{
    private float _horizontal;
    public float speed;
    public float jumpforce;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _grounded;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public int attackpower = 40;
    public float attackrate = 2.0f;
    private float nextattacktime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (_horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (_horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }


        _animator.SetBool("running", _horizontal != 0.0f);
        Debug.DrawRay(transform.position, Vector3.down * 0.25f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.25f))
        {
            _grounded = true;
        }
        else _grounded = false;

        _animator.SetBool("jumping", !_grounded);
        if (Input.GetKeyDown(KeyCode.W) && _grounded)
        {

            jump();

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(Time.time >= nextattacktime)
            {
                Attack();
                nextattacktime = Time.time + 1f / attackrate;
            }
            

            
        }

        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }

    private void jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpforce);

    }
    private void Attack()
    {
        int random = Random.Range(1, 4);
        _animator.SetTrigger("attack");
        _animator.SetInteger("attacknum", random);
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemylayer);

        foreach (Collider2D enemy in hitenemies)
        {
            
            enemy.GetComponent<Enemy>().takedamage(attackpower);
        }
    }

    private void FixedUpdate()
    {
        
        _rigidbody2D.velocity = new Vector2(_horizontal * speed, _rigidbody2D.velocity.y);

    }
}
