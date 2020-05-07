using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UserEquipSlot : MonoBehaviour
{
    public bool OnEquipItem; //현제 슬롯이 아이템을 장작했으면 트루 // 아니면 펠스

    public GameManager.e_Itemtype e_type;
    public int type;
    public int Rank;
    public int Scericse;
    public int id;
    public int number;
    public GameObject ObjectBuffer; //현제 장착중인 아이템을 저장하기위한 수단
    public  BuffStaters Buff;


    [SerializeField]
    public struct BuffStaters
    {
        public int atk;
        public int def;
        public float speed;

    }

    public void UserStateUpdate(int type)
    {
        if(type  == -1)
        {
            Debug.LogWarning("인덱스의 값이 -1을 가져왔습니다");
            return;
        }

        if (type != 1)    type = 0;

        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = DataBase.getInstance().GetItem[type][id].ItemImg;

        Buff.atk = DataBase.getInstance().GetItem[type][id].m_Atk;
        Buff.def = DataBase.getInstance().GetItem[type][id].m_Def;
        Buff.speed = DataBase.getInstance().GetItem[type][id].m_Speed;

        NewFunction();
    }
    public void NewFunction()
    {
        int a_atk = 0;
        int a_def = 0;
        float a_speed = (int)0;

        for (int i = 0; i < GameManager.getInstance().m_EquipSlot.Length; i++)
        {
            UserEquipSlot targetslot = GameManager.getInstance().m_EquipSlot[i].GetComponent<UserEquipSlot>();

            a_atk += targetslot.Buff.atk;
            a_def += targetslot.Buff.def;
            a_speed += targetslot.Buff.speed;
        }

        GameManager.getInstance().SetAttack(a_atk);
        GameManager.getInstance().SetDefenc(a_def);
        GameManager.getInstance().SetSpeed(a_speed);
    }

    private void Realese(int type)
    {
        id = -1;
        Buff.atk = 0;
        Buff.def = 0;
        Buff.speed = 0;

        ObjectBuffer.SetActive(true);
        GameManager.getInstance().SetAttack(Buff.atk);
        GameManager.getInstance().SetDefenc(Buff.def);
        GameManager.getInstance().SetSpeed(Buff.speed);
        switch(type)
        {
            case 0 :
           // gameObject.GetComponent<Image>().sprite =(UnityEngine.Sprite)DataBase.getInstance().testimg[0];
            break;
            case 1:
          //  gameObject.GetComponent<Image>().sprite = (UnityEngine.Sprite)DataBase.getInstance().testimg[0];
            break;
            case 2:
          //  gameObject.GetComponent<Image>().sprite = (UnityEngine.Sprite)DataBase.getInstance().testimg[0];
            break;
            case 3:
          //  gameObject.GetComponent<Image>().sprite = (UnityEngine.Sprite)DataBase.getInstance().testimg[0];
            break;
            
        }
        

        ObjectBuffer = null;
    }


    private int r()
    {
        int rank =  GameManager.getInstance().m_EquipSlot[0].GetComponent<UserEquipSlot>().Rank;
        for (int i = 0; i < GameManager.getInstance().m_EquipSlot.Length; i++)
        {
            UserEquipSlot targetslot = GameManager.getInstance().m_EquipSlot[i].GetComponent<UserEquipSlot>();

            if (targetslot.Rank != rank)
            { 
                return -1;
            }
        }

       
        return rank;


    }
    public int s()
    {
      
        int scericse = GameManager.getInstance().m_EquipSlot[0].GetComponent<UserEquipSlot>().Scericse;

        for (int i = 0; i < GameManager.getInstance().m_EquipSlot.Length; i++)
        {
            UserEquipSlot targetslot = GameManager.getInstance().m_EquipSlot[i].GetComponent<UserEquipSlot>();

            if (targetslot.Scericse != scericse)
            {

                return -1;
            }
        }


        return scericse;


    }

    public void ShowSetAction()
    {
        Sprite img = null;
        int R_Result = r();
        int S_Result = s();

        string str_Name = "";
        string Action = "";

    

        if (R_Result != -1)
        {

         img = DataBase.getInstance().dic_Rank[S_Result].img;
         str_Name = GameManager.getInstance().RanktoString(R_Result);
         Action = str_Name + "랭크 세트 효과를 발동합니다";

         GameManager.getInstance().instancdic["Rimg"].GetComponent<Image>().sprite = img;
         GameManager.getInstance().instancdic["RName"].GetComponent<Text>().text = str_Name;
         GameManager.getInstance().instancdic["RAction"].GetComponent<Text>().text = Action;
       
            
        }

        if (S_Result != -1)
        {
        img =  DataBase.getInstance().dic_Constellation[Scericse].img;
        str_Name = GameManager.getInstance().ConstellationtoString(S_Result); ;
        Action = str_Name + "랭크 세트 효과를 발동합니다";



        GameManager.getInstance().instancdic["Simg"].GetComponent<Image>().sprite = img;
        GameManager.getInstance().instancdic["SName"].GetComponent<Text>().text = str_Name;
        GameManager.getInstance().instancdic["SAction"].GetComponent<Text>().text = Action;

        }

    }

}
