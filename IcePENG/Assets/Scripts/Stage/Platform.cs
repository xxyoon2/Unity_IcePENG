using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float _dropCooltime = 3f; // 몇 초가 지나면 추락하는가?
    private Vector2 _currentPos;

    private GameObject[] _items;

    private void OnBecameVisible()
    {
        Debug.Log("게임 오브젝트가 카메라 시야 내에 들어옴");
        _items = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            _items[i] = transform.GetChild(i).gameObject;
        }
        SetActiveRandomItems();
    }

    private void SetActiveRandomItems()
    {
        int result = Random.Range(0, 10);
        if (result >= 4)
        {
            return;
        }
        else
        {
            _items[result].SetActive(true);
        }
    }
    // 충돌한 대상이 플레이어일 시 추락 카운트다운 시작
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

    // 추락 대기시간 동안 카운트 후 플랫폼 추락 코루틴 실행
    IEnumerator ActionBeforeDrop()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= _dropCooltime)
        {
            elapsedTime += 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(UpdateDropPos());
        yield return null;
    }

    // 플랫폼 추락
    IEnumerator UpdateDropPos()
    {
        float dropEndYPos = _currentPos.y - 10f;
        while (_currentPos.y >= dropEndYPos)
        {
            _currentPos = transform.position;
            _currentPos.y -= 0.5f;
            gameObject.transform.position = _currentPos;
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.SetActive(false);
        yield break;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("게임 오브젝트가 카메라 시야 밖으로 나감");
        Invoke("makeObjectsActiveFalse", _dropCooltime);
    }

    void makeObjectsActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
