using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    public float MoveSpeed = 15f; // �̵� �ӵ�
    private void Start()
    {
        GameManager.Instance.GameStart.AddListener(DetermineScroll);
    }

    private void DetermineScroll(bool _shouldObjectsScroll)
    {
        if(_shouldObjectsScroll)
        {
            StartCoroutine(Scroll());
        }
        else
        {
            StopAllCoroutines();
        }
    }
    private IEnumerator Scroll()
    {
        while(true)
        {
            // ���� ������Ʈ�� �������� ���� �ӵ��� ���� �̵��ϴ� ó��
            transform.Translate(-1 * MoveSpeed * Time.deltaTime, 0f, 0f);
            yield return new WaitForSeconds(0.0001f);
        }
    }
}
