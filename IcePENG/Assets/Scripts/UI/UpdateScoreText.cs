using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScoreText : MonoBehaviour
{
    public TextMeshProUGUI _ScoreUI;

    void Start()
    {
        GameManager.Instance.UpdateScore.RemoveListener(ChangeScore);
        GameManager.Instance.UpdateScore.AddListener(ChangeScore);

        _ScoreUI.text = $"Score : {GameManager.Instance.CurrentScore}";
    }

    public void ChangeScore(int currentScore)
    {
        _ScoreUI.text = $"Score : {currentScore}";
    }
}
