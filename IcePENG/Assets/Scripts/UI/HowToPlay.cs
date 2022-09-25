using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.GameStart.RemoveListener(HideText);
        GameManager.Instance.GameStart.AddListener(HideText);
    }

    public void HideText(bool IsGameStarting)
    {
        gameObject.SetActive(!IsGameStarting);
    }
}
