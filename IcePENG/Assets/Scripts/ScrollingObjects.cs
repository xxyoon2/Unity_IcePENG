using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    public float MoveSpeed = 15f; // 이동 속도

    private void Update()
    {
        // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
        transform.Translate(-1 * MoveSpeed * Time.deltaTime, 0f, 0f);

    }
}
