using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Slot[] slots;

    private Vector3 _target;
    private ItemInfo carryingitem;              //�̵� ��Ű�� �ִ� ������ ����

    private Dictionary<int, Slot> slotDictionary;   //���� ������ �����ϴ� �ڷᱸ��

    // Start is called before the first frame update
    void Start()
    {
        slotDictionary = new Dictionary<int, Slot>();       //���� ��ųʸ� �ʱ�ȭ

        for (int i = 0; i < slots.Length; i++)               //�� ������ ID�� �����ϰ� ��ųʸ��� �߰�
        {
            slots[i].id = i;
            slotDictionary.Add(i, slots[i]);
        }
        PlaceRandomitem();
        PlaceRandomitem();
        PlaceRandomitem();
        PlaceRandomitem();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))            //���콺 ��ư�� ������ ��
        {
            SendRayCast();
        }
        if (Input.GetMouseButton(0) && carryingitem)           //���콺 ��ư ���� ���¿��� ������ ���� �� �̵� ó��
        {         
            Onitemselected();

        }

        if (Input.GetMouseButton(0))           //���콺 ��ư ���� ���¿��� ������ ���� �� �̵� ó��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                //ȭ���� ���콺 ��ǥ�� ���ؼ� ���� ���� �����ɽ���
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
           
        }
        if (Input.GetMouseButtonUp(0))          //���콺 ��ư ���� �̺�Ʈ ó��
        {
            SendRayCast();
        }
        if (Input.GetKeyDown(KeyCode.A))    //�����̽� Ű�� ������ �� ���� ������ ��ġ > ���� Ŭ�� �� ������ ���� > AŰ�� �ٲ��
        {
            PlaceRandomitem();
        }
    }

    void SendRayCast()      //���콺 Ŭ�� �� Ray �߻�
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                //ȭ���� ���콺 ��ǥ�� ���ؼ� ���� ���� �����ɽ���
        RaycastHit hit;                                                               //hit ���� ����

       

        if (Physics.Raycast(ray, out hit))                               //hit�� ���� ���� ���
        {
            Debug.Log(hit.collider.gameObject.name);
            var slot = hit.transform.GetComponent<Slot>();          //hit�� slot Component�� �����´�
            if (slot.state == Slot.SLOTSTATE.FULL && carryingitem == null)      //������ ���Կ��� �������� ��� �̵��ϴ� ���
            {
                string itemPath = "Prefabs/Item_Grabbed_" + slot.itemObject.id.ToString("000");     //���� ������ ����
                var itemGO = (GameObject)Instantiate(Resources.Load(itemPath));                     //�ش� ��θ� ���ؼ� ����
                itemGO.transform.position = slot.transform.position;                                //slot ��ġ�� �����ϰ� ����
                itemGO.transform.localScale = Vector3.one * 2;                                      //ũ��� 2���   
                carryingitem = itemGO.GetComponent<ItemInfo>();                                     //���� �������� carryingitem�� �Է�                
                carryingitem.initDummy(slot.id, slot.itemObject.id);                                //���������� ����

                slot.itemGrabbed();                                                                   //���� �������� ������  
            }
            else if (slot.state == Slot.SLOTSTATE.EMPTY && carryingitem != null)         //�� ���Կ� ������ ��ġ
            {
                slot.Createitem(carryingitem.itemld);               //��� �ֶ� ������ ���̵� �����ͼ� ���Կ� �����ϰ�    
                Destroy(carryingitem.gameObject);                   //��� �ִ� ������ ����
                PlaceRandomitem();
            }
            else if (slot.state == Slot.SLOTSTATE.FULL && carryingitem != null)          //�����۳��� ���� ���� ���� ������
            {
                if (slot.itemObject.id == carryingitem.itemld)                      //���� ���� �ִ� ������ id�� ��� �ִ� �������� ���� ���
                {
                    OnitemMergedWithTarget(slot.id);                            //������ ����
                    PlaceRandomitem();
                }
                else
                {
                    OnitemCarryFail();      //������ ��ġ ����
                    PlaceRandomitem();
                }
            }

        }
        else //hit �� ���� ���
        {
            if (!carryingitem)          //��� �ִ� �����۵� ���� ���
            {
                return;
            }
            OnitemCarryFail();      //������ ��ġ ����
        }
    }
    //�������� �����ϰ� ���콺 ��ġ�� �̵�
    void Onitemselected()
    {
        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //���� ��ǥ���� ���콺 ������ ���� �����ͼ� _target�Է�
        _target.z = 2;                                              //2D

        var delta = 10 * Time.deltaTime;        //�̵��ӵ� ����

        delta *= Vector3.Distance(transform.position, _target);
        carryingitem.transform.position = Vector3.MoveTowards(carryingitem.transform.position, _target, delta);         //�Լ��� �̵�
    }

    //�������� ���԰� ���� �� �� �Լ�
    void OnitemMergedWithTarget(int targetSlotld)       //�������� ���԰� ���� �� �� �Լ�
    {
        var slot = GetSlotByld(targetSlotld);           //���� ���Կ� �ִ� ������Ʈ�� �����ͼ� �ı�
        Destroy(slot.itemObject.gameObject);
        slot.Createitem(carryingitem.itemld + 1);       //���� �Ǿ����Ƿ� ���� ������Ʈ�� ����
        Destroy(carryingitem.gameObject);               //����ִ� ���� ������Ʈ�� �ı�
    }
    void OnitemCarryFail()          //������ ��ġ ���� �� ����
    {
        var slot = GetSlotByld(carryingitem.slotld);            //��� �ִ� �������� ���� ���� ��ġ
        slot.Createitem(carryingitem.itemld);                   //�ش� ���Կ� �ٽ� ����
        Destroy(carryingitem.gameObject);                       //��� �ִ� ���� �������� ����
    }
    void PlaceRandomitem()
    {
        if (AllSlotsOccupied())
        {
            Debug.Log("������ �� ������ => ���� �Ұ�");
            return;
        }

        var rand = UnityEngine.Random.Range(0, slots.Length);               //���� ������ ���� ���� ��ȣ�� rand�� �Է�
        var slot = GetSlotByld(rand);                                       //Rand ���� index���� ���ؼ� slot ��ü�� �����´�

        while (slot.state == Slot.SLOTSTATE.FULL)               //���� ���°� FULL�� �ƴҶ����� ���� ��ȣ�� ã�Ƽ� ����
        {
            rand = UnityEngine.Random.Range(0, slots.Length);           //���� ������ ���� ���� ��ȣ�� rand�� �Է�
            slot = GetSlotByld(rand);                               //Rand ���� index���� ���ؼ� slot ��ü�� �����´�
        }
        slot.Createitem(0);                                 //�� ������ �߰��ϸ� 0��° �������� ����
    }
    bool AllSlotsOccupied()                     //������ ä���� �ִ��� Ȯ�� �ϴ� �Լ�
    {
        foreach (var slot in slots)                      //���� �迭�� �ϳ��� Ȯ���ϸ鼭 foreach �� �ݺ�
        {
            if (slot.state == Slot.SLOTSTATE.EMPTY)     //���� �迭�� �� �ڸ��� ������
            {
                return false;           //�߰��� false�� ����
            }
        }
        return true;                //�� �������Ƿ� true�� ����
    }
    //���� ID�� ������ �˻�
    Slot GetSlotByld(int id)        //���� ID�� ������ �˻�
    {
        return slotDictionary[id];      //��ųʸ��� ����ִ� Slot Class ��ȯ (��ȣ�� ���ؼ�)
    }
}
