using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int lifeCount = 0;

    void Start()
    {
        GameManager.Instance.LifeChange.RemoveListener(LifeOperation);
        GameManager.Instance.LifeChange.AddListener(LifeOperation);
    }

    public void LifeOperation(int life)
    {
        // life와 lifeCount가 같을 때, 혹은 lifeCount가 이미 최대일 때 return; <- 이건 나중에
        if (life == lifeCount)
        {
            return;
        }

        // 증가일 때
        if (life < lifeCount)
        {
            // 하트 채우고
            //
            return;
        }

        // 감소일 때
        if (life > lifeCount)
        {
            // 하트 지우고
            
            return;
        }
    }
}
