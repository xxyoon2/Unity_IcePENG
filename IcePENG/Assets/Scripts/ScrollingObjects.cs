using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    public float MoveSpeed = 15f; // �̵� �ӵ�

    private void Update()
    {
        // ���� ������Ʈ�� �������� ���� �ӵ��� ���� �̵��ϴ� ó��
        transform.Translate(-1 * MoveSpeed * Time.deltaTime, 0f, 0f);

    }
}
