using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float _dropCooltime = 3f; // 몇 초가 지나면 추락하는가?
    private Vector2 currentPos;

    private void Start()
    {
        currentPos = transform.position;
    }

    // 충돌한 대상이 플레이어일 시 추락 카운트다운 시작
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ActionBeforeDrop");
        }
    }

    // 추락 대기시간 동안 카운트 후 플랫폼 추락 코루틴 실행
    IEnumerator ActionBeforeDrop()
    {
        bool    isPlatformShaked = false;
        float   elapsedTime = 0f;

        while(elapsedTime <= _dropCooltime)
        {
            elapsedTime += 0.05f;
            isPlatformShaked = !isPlatformShaked;
            // 플랫폼 흔들리는 모션
            if(isPlatformShaked)
            {
                currentPos.x -= 0.1f;
            }
            else
            {
                currentPos.x += 0.1f;
            }
            transform.position = currentPos;

            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(UpdateDropPos());
        yield return null;
    }

    // 플랫폼 추락
    IEnumerator UpdateDropPos()
    {
        float dropEndYPos = currentPos.y - 10f;
        while(currentPos.y >= dropEndYPos)
        {
            currentPos.y--;
            gameObject.transform.position = currentPos;
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.SetActive(false);
        yield break;
    }
}
