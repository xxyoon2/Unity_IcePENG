using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    private int _highScore;
    private int _currentScore;

    private TextMeshProUGUI _ui;
    private AudioSource _audio;

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        _audio = GetComponent<AudioSource>();
        _highScore = GameManager.Instance.BestScore;
        _currentScore = GameManager.Instance.CurrentScore;

        _audio.Play();
    }
    
    private void Start()
    {
        _ui.text = $"Score:{_currentScore}\nHigh Score: {_highScore}";
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
