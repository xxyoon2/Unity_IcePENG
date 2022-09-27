using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Update()
    {
        if(GameManager.Instance.StageCount <= 3 && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("StartScene");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("StageInfo");
        }
    }
}
