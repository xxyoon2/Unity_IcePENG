using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehavior<GameManager>
{
    public int BestScore;
    public int StageCount;
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("IcePeng_BestScore", 0);
    }

#region StartGame
    public UnityEvent<bool> GameStart = new UnityEvent<bool>();
    public bool IsPlayerStartGame = false;

    public void PlayGame(bool shouldObjectsScroll)
    {
        GameStart.Invoke(shouldObjectsScroll);
        IsPlayerStartGame = shouldObjectsScroll;
        StartCoroutine("ScoreCounter");
    }
#endregion

#region Life
    public UnityEvent<int> LifeChange = new UnityEvent<int>();

    public void UpdateLife(int life)
    {
        LifeChange.Invoke(life);
    }
#endregion

#region Score
    public UnityEvent<int> UpdateScore = new UnityEvent<int>();
    public int CurrentScore = 0;
    
    IEnumerator ScoreCounter()
    {
        CurrentScore = 0;
        UpdateScore.Invoke(BestScore);

        while (true)
        {
            yield return new WaitForSeconds(10f);
            CurrentScore += 100;
            if (CurrentScore > BestScore)
            {
                UpdateScore.Invoke(CurrentScore);
            }
        }
    }
#endregion

#region EndGame
    public void EndGame()
    {
        StopCoroutine("ScoreCounter");
        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            PlayerPrefs.SetInt("IcePeng_BestScore", BestScore);
        }
        IsPlayerStartGame = false;
        StageCount = 1;
        SceneManager.LoadScene("GameOverScene");
    }
#endregion   
}
