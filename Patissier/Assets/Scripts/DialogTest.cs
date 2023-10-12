using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem;
    public int dialogIndex;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog(dialogIndex, true)); //��ٸ��� �Լ� , ���̾�α� �ý����� �Ϸ� �ɶ� ���� 
        //�μ��� ��� ��ȣ
    }
}