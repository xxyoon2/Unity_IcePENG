using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    public float MoveSpeed = 15f; // 이동 속도
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
            // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
            transform.Translate(-1 * MoveSpeed * Time.deltaTime, 0f, 0f);
            yield return new WaitForSeconds(0.0001f);
        }
    }
}
