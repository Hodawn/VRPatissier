using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOver_Panel; // GameOver_Panel GameObject를 연결할 변수

    // GameOver_Panel을 활성화하는 메서드
    private void ActivateGameOverPanel()
    {
        if (GameOver_Panel != null)
        {
            GameOver_Panel.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverPanel이 할당되지 않았습니다!");
        }
    }
}
