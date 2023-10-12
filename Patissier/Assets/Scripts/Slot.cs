using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE     //���� ���°�
    {
        EMPTY,
        FULL
    }
    public int id;
    public Item itemObject;                     //������ ������ ����(Ŀ���� Clss)
    public SLOTSTATE state = SLOTSTATE.EMPTY;   //���°� �����Ѱ� ���� �� EMPTY �Է�

    private void ChangeStateTO(SLOTSTATE targetState)       //�ش� ���Կ� ���°��� ��ȯ �����ִ� �Լ�
    {
        state = targetState;
    }
    public void itemGrabbed()                       //������ Raycast�� ���ؼ� �������� �������
    {
        Destroy(itemObject.gameObject);         //�������� �������� ����
        ChangeStateTO(SLOTSTATE.EMPTY);     //������ �� ����(State)
    }
    public void Createitem(int id)
    {
        string itemPath = "Prefabs/item_" + id.ToString("000"); //������ ������ ���(Resources/Prefabs/item_000)���� ����
        var itemGO = (GameObject)Instantiate(Resources.Load(itemPath));//������ ��ο� �ִ� �������� ����
        //������ ���� ������Ʈ �ʱ�ȭ
        itemGO.transform.SetParent(this.transform);             //slot ������Ʈ ������ ����
        itemGO.transform.localPosition = Vector3.zero + new Vector3(0,0,1);          //���� ��ġ�� Vector3(0, 0 ,0)
        itemGO.transform.localScale = Vector3.one;              //���� Scale�� Vector3(1, 1, 1)
        //���� item ������Ʈ ������ �Է�
        itemObject = itemGO.GetComponent<Item>();               //������ ���� ������Ʈ�� item Class �� ����
        itemObject.init(id, this);                              //�Լ��� ���� �� �Է�

        ChangeStateTO(SLOTSTATE.FULL);                  //�����ؼ� ������ ������ ���ִ�
    }
}
