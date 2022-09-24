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
    }

    public void ChangeScore(int bestScore)
    {
        _ScoreUI.text = $"Score : {bestScore}";
    }
}
