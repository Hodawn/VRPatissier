using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // ���� ������ ��ȯ�� �� ����� �� �̸�
    public string nextSceneName = "LobbyScene";


    public void SkipToNextScene()
    {
        // ���� ������ ��ȯ
        SceneManager.LoadScene(nextSceneName);
    }
}
