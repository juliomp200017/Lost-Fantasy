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


    }

    private void jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpforce);

    }
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * speed, _rigidbody2D.velocity.y);

    }
}
