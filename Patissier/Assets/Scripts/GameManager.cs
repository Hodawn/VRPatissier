using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericSingleton<GameManager>
{
    public int playerScore = 0;                                 //관리할 플레이어 스코어
   
    

    // 다음 씬으로 전환할 때 사용할 씬 이름
    public string nextSceneName = "LobbyScene";

    public void SkipToNextScene()
    {
        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void inscreaseScore(int amount)
    {
        playerScore += amount;                              //함수를 통해서 스코어를 증가시킨다.
    }
    //public AudioClip Aspiration Woods(Area Theme);
    //private new AudioSource audio;
}