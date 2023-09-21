using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chat : MonoBehaviour
{
    public float displayDuration = 3f; // �̹����� �ؽ�Ʈ�� ǥ���� �ð� (��)
    private GameObject dialogPanel; // DialogPanel ���� ������Ʈ
    private bool isDisplaying = false; // �̹����� �ؽ�Ʈ�� ǥ�� ������ ����
    private float displayTimer = 0f; // �̹����� �ؽ�Ʈ ǥ�� Ÿ�̸�

    private void Start()
    {
        dialogPanel = GameObject.Find("Canvas").transform.Find("DialogPanel").gameObject;
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDisplaying) // �̹����� �ؽ�Ʈ�� ǥ�� ������ ���� ���
            {
                DisplayDialogPanel(); // DialogPanel ǥ�� �Լ� ȣ��
            }
        }
    }

    private void Update()
    {
        if (isDisplaying)
        {
            displayTimer += Time.deltaTime; // Ÿ�̸� ����

            if (displayTimer >= displayDuration)
            {
                HideDialogPanel(); // DialogPanel ����� �Լ� ȣ��
            }
        }
    }

    private void DisplayDialogPanel()
    {
        dialogPanel.SetActive(true); // DialogPanel Ȱ��ȭ
        isDisplaying = true; // ǥ�� ���� ���·� ����
        displayTimer = 0f; // Ÿ�̸� �ʱ�ȭ
    }

    private void HideDialogPanel()
    {
        dialogPanel.SetActive(false); // DialogPanel ��Ȱ��ȭ
        isDisplaying = false; // ǥ�� ������ ���� ���·� ����
    }
}
