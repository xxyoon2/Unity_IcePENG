using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float _width;
    private float _yPos;
    private Vector2 _resetPosition;

    private void Awake()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        _width = bc.size.x - 0.1f;
        _yPos = transform.position.y;

        _resetPosition = new Vector2(_width, _yPos);
    }

    // 현재 배경 오브젝트가 기존 너비만큼 왼쪽으로 갈 시 위치 리셋
    private void Update()
    {
        if(transform.position.x <= -_width)
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        transform.position = _resetPosition;
    }

}
