using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOver_Panel; // GameOver_Panel GameObject�� ������ ����

    // GameOver_Panel�� Ȱ��ȭ�ϴ� �޼���
    private void ActivateGameOverPanel()
    {
        if (GameOver_Panel != null)
        {
            GameOver_Panel.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverPanel�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }
}
