using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private int _stageInfo;
    void Start()
    {
        _stageInfo = GameManager.Instance.StageCount;
        switch (_stageInfo)
        {
            case 1:
                Invoke("LoadStage1", 2f);
                break;
            case 2:
                Invoke("LoadStage2", 2f);
                break;
        }
    }

    void LoadStage1()
    {
        SceneManager.LoadScene("Play");
        return;
    }

    void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");

    }
}
