using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // 다음 씬으로 전환할 때 사용할 씬 이름
    public string nextSceneName = "LobbyScene";


    public void NextScene()
    {
        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }
}
