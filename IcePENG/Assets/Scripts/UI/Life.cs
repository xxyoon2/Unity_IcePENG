using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private int lifeCount = 3;

    public Sprite LifeSprite;
    public Sprite EmptyLifeSprite;

    public GameObject LifeBar;
    public GameObject[] Lifes = new GameObject[5];

    private Image _image;

    void Start()
    {
        GameManager.Instance.LifeChange.RemoveListener(LifeOperation);
        GameManager.Instance.LifeChange.AddListener(LifeOperation);
/*
        for (int i = 0; i < 5; ++i)
        {
            Lifes[i] = LifeBar.transform.GetChild(i).Image;
            _image = Lifes[i].GetComponent<Image>();

            if (i < lifeCount)
            {
                Lifes[i]._image = LifeSprite;
            }
            else
            {
                Lifes[i]._image = EmptyLifeSprite;
            }

            Debug.Log($"{Lifes[i]}");
        }
*/
    }

    public void LifeOperation(int elapseLife)
    {
        // life와 lifeCount가 같을 때, 혹은 lifeCount가 이미 최대일 때 return; <- 이건 나중에
        if (elapseLife == lifeCount)
        {
            return;
        }

        // 감소
        if (elapseLife < lifeCount)
        {
            // 하트 지우기
            _image = Lifes[elapseLife].GetComponent<Image>();
            _image.sprite = EmptyLifeSprite;
        }

        // 증가
        if (elapseLife > lifeCount)
        {
            // 하트 채우기
            _image = Lifes[lifeCount].GetComponent<Image>();
            _image.sprite = LifeSprite;
        }

        lifeCount = elapseLife;
    }
}
