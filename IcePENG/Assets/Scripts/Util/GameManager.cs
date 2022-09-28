using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehavior<GameManager>
{
    private AudioSource _audio;

    public int BestScore;
    public int StageCount = 1;

    void Start()
    {
        _audio = GetComponent<AudioSource>();

        BestScore = PlayerPrefs.GetInt("IcePeng_BestScore", 0);
    }

#region StartGame
    public UnityEvent<bool> GameStart = new UnityEvent<bool>();
    public bool IsPlayerStartGame = false;

    public void PlayGame(bool shouldObjectsScroll)
    {
        GameStart.Invoke(shouldObjectsScroll);
        IsPlayerStartGame = shouldObjectsScroll;
        PlayerSlipOnIce(false);
        StartCoroutine("ScoreCounter");
    }
#endregion

#region Audio
    public void PlayerSlipOnIce(bool isPlayerOnIce)
    {
        if (!isPlayerOnIce)
        {
            _audio.Stop();
            return;
        }
        else
        {
            _audio.Play();
            return;
        }
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
        UpdateScore.Invoke(CurrentScore);

        while (true)
        {
            yield return new WaitForSeconds(10f);

            CurrentScore += 100;
            UpdateScore.Invoke(CurrentScore);
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
