using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericSingleton<GameManager>
{
    public int playerScore = 0;                                 //������ �÷��̾� ���ھ�
   
    

    // ���� ������ ��ȯ�� �� ����� �� �̸�
    public string nextSceneName = "LobbyScene";
    

    public void SkipToNextScene()
    {
        // ���� ������ ��ȯ
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
        playerScore += amount;                              //�Լ��� ���ؼ� ���ھ ������Ų��.
    }
    //public AudioClip Aspiration Woods(Area Theme);
    //private new AudioSource audio;

    
}