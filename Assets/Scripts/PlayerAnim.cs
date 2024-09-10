using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;


    private void Start()
    {
        _rb = transform.parent.GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_rb.velocity != Vector3.zero)
        {
            _animator.SetBool("walk" , true);
            _animator.applyRootMotion = false;
        }
        else
        {
            _animator.SetBool("walk" , false);
            _animator.applyRootMotion = true;
        }
    }
}
