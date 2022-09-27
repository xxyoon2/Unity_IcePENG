using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearText : MonoBehaviour
{
    private TextMeshProUGUI _ui;
    private AudioSource _audio;

    private void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        _audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        int stageInfo = GameManager.Instance.StageCount;
        if(stageInfo >= 3)
        {
            _ui.text = "Congraturation!";
            _audio.Play();
        }
        else
        {
            _ui.text = "CLEAR";
        }
    }
}
