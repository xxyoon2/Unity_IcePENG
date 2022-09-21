using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    
    public float JumpForce = 700f; // 점프 속도 필요하려나?

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_input.IsPlayerJump)
        {
            Debug.Log("점프!!");
            Jump();
        }
    }

    private void Jump()
    {
        // 점프
        //_rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(new Vector2(0f, JumpForce);

    }

    /*
        처리해야할 것
        1. 플레이어가 플랫폼을 밟고 있는지
        2. 플레이어가 점프시 착지하는 위치
            2_1. 플랫폼 위
            2_2. 플랫폼 모서리
            2_3. 플랫폼 옆
            2_4. 구덩이
            2_5. 장애물
    */
}
