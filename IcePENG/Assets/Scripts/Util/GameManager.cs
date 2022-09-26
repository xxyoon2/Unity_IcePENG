using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehavior<GameManager>
{
    public int BestScore;

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
            Debug.Log($"{BestScore}");
            CurrentScore += 100;
            UpdateScore.Invoke(CurrentScore);
        }
    }
#endregion

#region EndGame
    private void EndGame()
    {
        StopCoroutine("ScoreCounter");
        BestScore = PlayerPrefs.GetInt("IcePeng_BestScore", 0);

        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            Debug.Log($"{BestScore}");
            PlayerPrefs.SetInt("IcePeng_BestScore", BestScore);
        }
    }
#endregion   
}
