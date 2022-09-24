using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehavior<GameManager>
{
    // life system
    // game key
    // score system

#region StartGame
    // 플레이어가 깃발 지나갔을 때
#endregion

#region Score
    public UnityEvent UpdateScore = new UnityEvent();
    
    public int CurrentScore = 0;
    public int BestScore = -100;
#endregion

    public void GameStart()
    {
        // 게임 키 설명 UI 지우고
        // 게임 플렛폼 움직이도록
    }
}
