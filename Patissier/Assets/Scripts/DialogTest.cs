using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    //Dialog 객체를 따로 정의 하지않아 오류가 있어서 주석 처리함
    //public void StartDialog(Dialog dialog)
    //{
    //    dialogBox.SetActive(true);

    //    sentences.Clear();

    //    foreach (string sentence in dialog.sentences)
    //    {
    //        sentences.Enqueue(sentence);
    //    }

    //    DisplayNextSentence();
    //}

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        dialogBox.SetActive(false);
    }
}