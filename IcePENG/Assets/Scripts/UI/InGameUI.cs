using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    // HowToPlay
    public GameObject HowToPlayText;

    // Life
    public Sprite LifeSprite;
    public Sprite EmptyLifeSprite;

    public GameObject[] Lifes = new GameObject[5];

    private Image _image;
    private int _lifeCount = 3;

    // UpdateScoreText
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        // HowToPlay
        GameManager.Instance.GameStart.RemoveListener(HideText);
        GameManager.Instance.GameStart.AddListener(HideText);

        // Life
        GameManager.Instance.LifeChange.RemoveListener(LifeOperation);
        GameManager.Instance.LifeChange.AddListener(LifeOperation);

        // UpdateScoreText
        GameManager.Instance.UpdateScore.RemoveListener(ChangeScore);
        GameManager.Instance.UpdateScore.AddListener(ChangeScore);

        ScoreText.text = $"Score : {GameManager.Instance.CurrentScore}";
    }

    public void HideText(bool IsGameStarting)
    {
        HowToPlayText.SetActive(!IsGameStarting);
    }

    public void LifeOperation(int elapseLife)
    {
        // life와 lifeCount가 같을 때, 혹은 lifeCount가 이미 최대일 때 return; <- 이건 나중에
        if (elapseLife == _lifeCount)
        {
            return;
        }

        // 감소
        if (elapseLife < _lifeCount)
        {
            // 하트 지우기
            _image = Lifes[elapseLife].GetComponent<Image>();
            _image.sprite = EmptyLifeSprite;
        }

        // 증가
        if (elapseLife > _lifeCount)
        {
            // 하트 채우기
            _image = Lifes[_lifeCount].GetComponent<Image>();
            _image.sprite = LifeSprite;
        }

        _lifeCount = elapseLife;
    }

    public void ChangeScore(int currentScore)
    {
        ScoreText.text = $"Score : {currentScore}";
    }
}
