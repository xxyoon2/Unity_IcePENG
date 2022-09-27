using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageText : MonoBehaviour
{
    private TextMeshProUGUI _ui;
    private int _stageInfo;
    private void OnEnable()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        _stageInfo = GameManager.Instance.StageCount;
    }
    void Start()
    {
        _ui.text = $"STAGE 0{_stageInfo}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
