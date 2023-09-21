using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chat : MonoBehaviour
{
    public float displayDuration = 3f; // 이미지와 텍스트를 표시할 시간 (초)
    private GameObject dialogPanel; // DialogPanel 게임 오브젝트
    private bool isDisplaying = false; // 이미지와 텍스트가 표시 중인지 여부
    private float displayTimer = 0f; // 이미지와 텍스트 표시 타이머

    private void Start()
    {
        dialogPanel = GameObject.Find("Canvas").transform.Find("DialogPanel").gameObject;
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDisplaying) // 이미지와 텍스트가 표시 중이지 않은 경우
            {
                DisplayDialogPanel(); // DialogPanel 표시 함수 호출
            }
        }
    }

    private void Update()
    {
        if (isDisplaying)
        {
            displayTimer += Time.deltaTime; // 타이머 증가

            if (displayTimer >= displayDuration)
            {
                HideDialogPanel(); // DialogPanel 숨기는 함수 호출
            }
        }
    }

    private void DisplayDialogPanel()
    {
        dialogPanel.SetActive(true); // DialogPanel 활성화
        isDisplaying = true; // 표시 중인 상태로 변경
        displayTimer = 0f; // 타이머 초기화
    }

    private void HideDialogPanel()
    {
        dialogPanel.SetActive(false); // DialogPanel 비활성화
        isDisplaying = false; // 표시 중이지 않은 상태로 변경
    }
}
