using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float _dropCooltime = 3f; // �� �ʰ� ������ �߶��ϴ°�?
    private Vector2 _currentPos;

    private GameObject[] _items;

    private AudioSource _audio;
    public AudioClip PlatFormDropSoundEffect;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnBecameVisible()
    {
        _items = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            _items[i] = transform.GetChild(i).gameObject;
        }
        SetActiveRandomItems();
    }

    private void SetActiveRandomItems()
    {
        int result = Random.Range(0, 10);
        if (result >= 3)
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
            elapsedTime += 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(UpdateDropPos());
        yield return null;
    }

    // �÷��� �߶�
    IEnumerator UpdateDropPos()
    {
        float dropEndYPos = _currentPos.y - 10f;
        _audio.PlayOneShot(PlatFormDropSoundEffect);
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

    // ������ �÷����� ���� �߶� ��Ÿ�ӿ� �°� ��� �� ������Ʈ ��Ȱ��ȭ
    private void OnBecameInvisible()
    {
        Invoke("makeObjectsActiveFalse", _dropCooltime);
    }

    private void makeObjectsActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
