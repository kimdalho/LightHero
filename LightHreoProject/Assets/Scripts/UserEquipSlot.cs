using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UserEquipSlot : MonoBehaviour
{
    public bool OnEquipItem; //현제 슬롯이 아이템을 장작했으면 트루 // 아니면 펠스

    public GameManager.e_Itemtype type;
    public int id;
    public GameObject ObjectBuffer; //현제 장착중인 아이템을 저장하기위한 수단
    public  BuffStaters Buff;

    public void GetList()
    {

    }

    [SerializeField]
    public struct BuffStaters
    {
        public int atk;
        public int def;
        public float speed;

    }

    public void UserStateUpdate()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite =  DataBase.getInstance().dic_item[id].ItemImg;

        Buff.atk = DataBase.getInstance().dic_item[id].m_Atk;
        Buff.def = DataBase.getInstance().dic_item[id].m_Def;
        Buff.speed = DataBase.getInstance().dic_item[id].m_Speed;

        GameManager.getInstance().AddAttack(Buff.atk);
        GameManager.getInstance().AddDefenc(Buff.def);
        GameManager.getInstance().AddSpeed(Buff.speed);
    }

    



}
