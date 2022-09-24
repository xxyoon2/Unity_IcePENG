using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    private TextMeshProUGUI _ui;
    private int _bestScore;
    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        _bestScore = GameManager.Instance.BestScore;
    }
    private void Start()
    {
        _ui.text = $"Score:{_bestScore}";
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
