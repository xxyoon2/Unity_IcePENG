using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    public float MoveSpeed = 0.02f;
    public float JumpForce = 5f;

    public int life = 3;
    private int _graceTime = 2;

    private static readonly float MIN_NORMAL_Y = Mathf.Sin(80f * Mathf.Deg2Rad);

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

    // 이동
    private void Move()
    {
        if (_input.X == 0)
        {
            return;
        }

        // 스프라이트 방향 전환
        if (_input.X > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }

        if (_input.X < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        _rigidbody.AddForce(new Vector2(MoveSpeed * _input.X, 0f), ForceMode2D.Impulse);
    }


    // 점프
    private void Jump()
    {
        if (_animator.GetBool("isJumping"))
        {
            return;
        }

        _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        _animator.SetBool("isJumping",true);
    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");
        StartCoroutine("GracePeriod");
    }

    IEnumerator GracePeriod()
    {
        Debug.Log("우가");
        this.gameObject.layer = 9;
        
        float elapseTime = 0f;
        while (elapseTime <= _graceTime)
        {
            Debug.Log("깜");
            yield return new WaitForSeconds(0.25f);
            Debug.Log("빡");
            yield return new WaitForSeconds(0.25f);

            elapseTime += Time.deltaTime;
        }

        this.gameObject.layer = 0;
        yield return null;
    }

    // 플레이어 사망
    private void Die() 
    {
        _animator.SetTrigger("dead");
        _rigidbody.velocity = Vector2.zero;
        this.gameObject.layer = 8;
        GameManager.Instance.EndGame();
        
    }

    // 충돌 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 사망 처리
        if (collision.gameObject.CompareTag("Hit"))
        {
            --life;
            if (life <= 0)
            {
                Die();
            }

            Hit();          
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            Die();
        }

        // 점프 체크
        ContactPoint2D point = collision.GetContact(0);
        if (point.normal.y >= MIN_NORMAL_Y)
        {
            _animator.SetBool("isJumping", false);
        }
    }
}