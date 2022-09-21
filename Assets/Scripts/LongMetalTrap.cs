using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongMetalTrap : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetTrigger("activate");
    }
}
