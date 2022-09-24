using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehavior<GameManager>
{
    // life system
    // game key
    // score system
    public int BestScore;

    void Start()
    {
        BestScore = PlayerPrefs.GetInt("IcePeng_BestScore", 0);
        PlayGame(); // 임시
    }

#region StartGame
    // 플레이어가 깃발 지나갔을 때
    public UnityEvent<bool> GameStart = new UnityEvent<bool>();

    private void PlayGame() // + 함수 이름 수정하셔도 됨
    {
        // + 플렛폼 움직이는 컴포넌트를 활성화 시키던가 혹은 플랫폼 movespeed를 0에서 6.5로 올리던가하면 될듯
        // 키 설명하는 Text 없애야함
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
            CurrentScore += 100;
            if (CurrentScore > BestScore)
            {
                UpdateScore.Invoke(CurrentScore);
            }
        }
    }
#endregion

#region EndGame
    private void EndGame()// + 함수 이름 수정하셔도 됨
    {
        StopCoroutine("ScoreCounter");
        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            PlayerPrefs.SetInt("IcePeng_BestScore", BestScore);
        }
    }

#endregion   
}
