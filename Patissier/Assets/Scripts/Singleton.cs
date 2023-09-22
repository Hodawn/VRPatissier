using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton instance { get; private set; }      //�ν��Ͻ��� ������ ����

    private void Awake()
    {
        if (instance == null)                               //instance �� NULL�϶�
        {
            instance = this;
            DontDestroyOnLoad(gameObject);                      //���� ������Ʈ�� Scene�� ��ȯ�ǰ� �ı����� ����
        }
        else
        {
            Destroy(gameObject);                                //1���� ������Ű�� ���� ������ ��ü�� �ı��Ѵ�.
        }
    }

    public int playerScore = 0;                                 //������ �÷��̾� ���ھ�

    public void inscreaseScore(int amount)
    {
        playerScore += amount;                              //�Լ��� ���ؼ� ���ھ ������Ų��.
    }
}
