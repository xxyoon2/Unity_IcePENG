using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float _dropCooltime = 3f; // �� �ʰ� ������ �߶��ϴ°�?
    private Vector2 _currentPos;

    private void Start()
    {
        _currentPos = transform.position;
    }

    // �浹�� ����� �÷��̾��� �� �߶� ī��Ʈ�ٿ� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ActionBeforeDrop");
        }
    }

    // �߶� ���ð� ���� ī��Ʈ �� �÷��� �߶� �ڷ�ƾ ����
    IEnumerator ActionBeforeDrop()
    {
        bool    isPlatformShaked = false;
        float   elapsedTime = 0f;

        while(elapsedTime <= _dropCooltime)
        {
            elapsedTime += 0.05f;
            isPlatformShaked = !isPlatformShaked;
            // �÷��� ��鸮�� ���
            yield return new WaitForSeconds(0.025f);
            _currentPos.x -= 0.1f;
            yield return new WaitForSeconds(0.025f);
            _currentPos.x += 0.1f;
            transform.position = _currentPos;
        }
        StartCoroutine(UpdateDropPos());
        yield return null;
    }

    // �÷��� �߶�
    IEnumerator UpdateDropPos()
    {
        float dropEndYPos = _currentPos.y - 10f;
        while(_currentPos.y >= dropEndYPos)
        {
            _currentPos.y--;
            gameObject.transform.position = _currentPos;
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.SetActive(false);
        yield break;
    }
}
