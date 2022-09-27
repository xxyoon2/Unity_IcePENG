using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTest : MonoBehaviour
{
    [SerializeField]
    private float _dropCooltime = 3f; // �� �ʰ� ������ �߶��ϴ°�?
    private Vector2 _currentPos;

    private GameObject[] _items;

    private void OnBecameVisible()
    {
        Debug.Log("���� ������Ʈ�� ī�޶� �þ� ���� ����");
        _items = new GameObject[4];
        for(int i = 0; i < 4; i++)
        {
            _items[i] = transform.GetChild(i).gameObject;
        }
        SetActiveRandomItems();
    }

    private void SetActiveRandomItems()
    {
        int result = Random.Range(0, 5);
        if (result == 4)
        {
            return;
        }
        else
        {
            _items[result].SetActive(true);
        }
    }
    // �浹�� ����� �÷��̾��� �� �߶� ī��Ʈ�ٿ� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.IsPlayerStartGame && collision.contacts[0].normal.y < 0.7f)
        {
            StartCoroutine("ActionBeforeDrop");
        }
        else
        {
            return;
        }
    }

    // �߶� ���ð� ���� ī��Ʈ �� �÷��� �߶� �ڷ�ƾ ����
    IEnumerator ActionBeforeDrop()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= _dropCooltime)
        {
            _currentPos = transform.position;
            elapsedTime += 0.05f;
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
        while (_currentPos.y >= dropEndYPos)
        {
            _currentPos = transform.position;
            _currentPos.y--;
            gameObject.transform.position = _currentPos;
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.SetActive(false);
        yield break;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("���� ������Ʈ�� ī�޶� �þ� ������ ����");
        gameObject.SetActive(false);
    }
}
