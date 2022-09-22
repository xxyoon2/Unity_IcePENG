using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    NONE,
    JUMP,
    SLIDE,
    DIE
}

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    public float MoveSpeed = 2f;
    public float JumpForce = 700f;

    private static readonly float MIN_NORMAL_Y = Mathf.Sin(20f * Mathf.Deg2Rad);

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_input.IsPlayerJump)
        {
            Jump();
        }

        if (_input.X != 0f)
        {
            _animator.SetBool("isWalking", true);
            Move();
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void Move()
    {
        if (_input.X == 0)
        {
            return;
        }

        if (_input.X > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        
        if (_input.X < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        _rigidbody.AddForce(Vector2.right * new Vector2(MoveSpeed * _input.X, 0f), ForceMode2D.Impulse);
    }


    private void Jump()
    {
        if (_animator.GetBool("isJumping"))
        {
            return;
        }

        // 점프
        _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        _animator.SetBool("isJumping",true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D point = collision.GetContact(0);
        if (point.normal.y >= MIN_NORMAL_Y)
        {
            _animator.SetBool("isJumping", false);
        }
    }
}
