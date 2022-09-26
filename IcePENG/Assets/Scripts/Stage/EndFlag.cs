using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("GameClearSceneLoad", 0.3f);
        }
        else
        {
            return;
        }
    }
    
    void GameClearSceneLoad()
    {
        SceneManager.LoadScene("GameClearScene");
    }
}
