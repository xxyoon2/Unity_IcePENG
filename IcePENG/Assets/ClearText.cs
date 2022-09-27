using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearText : MonoBehaviour
{
    private TextMeshProUGUI _ui;
    private void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        int stageInfo = GameManager.Instance.StageCount;
        if(stageInfo >= 3)
        {
            _ui.text = "Congraturation!";
        }
        else
        {
            _ui.text = "CLEAR";
        }
    }
}
