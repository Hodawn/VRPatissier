using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE     //슬로 상태값
    {
        EMPTY,
        FULL
    }
    public int id;
    public Item itemObject;                     //선언한 아이템 정의(커스텀 Clss)
    public SLOTSTATE state = SLOTSTATE.EMPTY;   //상태값 선언한것 정의 후 EMPTY 입력

    private void ChangeStateTO(SLOTSTATE targetState)       //해당 슬롯에 상태값을 변환 시켜주는 함수
    {
        state = targetState;
    }
    public void itemGrabbed()                       //유저가 Raycast를 통해서 아이템을 잡았을때
    {
        Destroy(itemObject.gameObject);         //슬롯위의 아이템을 삭제
        ChangeStateTO(SLOTSTATE.EMPTY);     //슬롯은 빈 상태(State)
    }
    public void Createitem(int id)
    {
        string itemPath = "Prefabs/item_" + id.ToString("000"); //생성할 아이템 경로(Resources/Prefabs/item_000)부터 생성
        var itemGO = (GameObject)Instantiate(Resources.Load(itemPath));//아이템 경로에 있는 프리팹을 생성
        //생성한 게임 오브젝트 초기화
        itemGO.transform.SetParent(this.transform);             //slot 오브젝트 하위로 설정
        itemGO.transform.localPosition = Vector3.zero + new Vector3(0,0,1);          //로컬 위치는 Vector3(0, 0 ,0)
        itemGO.transform.localScale = Vector3.one;              //로컬 Scale은 Vector3(1, 1, 1)
        //생성 item 컴포넌트 데이터 입력
        itemObject = itemGO.GetComponent<Item>();               //생성한 게임 오브젝트의 item Class 를 접근
        itemObject.init(id, this);                              //함수를 통해 값 입력

        ChangeStateTO(SLOTSTATE.FULL);                  //생성해서 아이템 슬롯이 차있다
    }
}
