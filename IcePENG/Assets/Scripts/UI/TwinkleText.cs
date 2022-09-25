using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwinkleText : MonoBehaviour
{
    private float _elapsedTime = 0f;
    private bool _isTextTurnoff = false;
    private TextMeshProUGUI _ui;

    private void Start()
    {
        _ui = GetComponent<TextMeshProUGUI>();   
    }
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= 0.5f)
        {
            _isTextTurnoff = !_isTextTurnoff;
            _elapsedTime = 0f;
        }
        if(_isTextTurnoff)
        {
            _ui.text = " ";
        }
        else
        {
            _ui.text = "PRESS ENTER TO START";
        }

    }
}
