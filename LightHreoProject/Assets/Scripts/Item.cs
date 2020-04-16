using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{

    [Header("item")]
    public int      id;
    public int      price;
    public string   m_Story;
    public float    m_Atk;
    public float    m_Def;
    public float    m_Speed;
    public GameManager.e_Itemtype part;

    [Header("unitem")]
    public Image ItemImg;
    Text ItemNameText;
    public Button btn;
    public bool SlotMod;


    public Item(int _id,int _itemtype ,  string _name, string _stroy , int _pri,float _atk ,float _def, float _speed)
    {
        id = _id;
        switch (_itemtype)
        {
            case 0:
                part = GameManager.e_Itemtype.헬멧;
                break;
            case 1:
                part = GameManager.e_Itemtype.무기;
                break;
            case 2:
                part = GameManager.e_Itemtype.방어구;
                break;
            case 3:
                part = GameManager.e_Itemtype.장신구;
                break;
        }

        m_Story = _stroy;
        price = _pri;
        m_Atk = _atk;
        m_Def = _def;
        m_Speed = _speed;
    }


    private void ItemComponetInit()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            string compo_name = gameObject.transform.GetChild(i).name;
            switch (compo_name)
            {
                case "ItemImg":
                    ItemImg = gameObject.transform.GetChild(i).GetComponent<Image>();
                    break;

                case "ItemNameText":
                    ItemNameText = gameObject.transform.GetChild(i).GetComponent<Text>();

                    break;
            }
        }
    }

    private void Start()
    {
     
        if(SlotMod == false)
        {
            btn = GetComponentInChildren<Button>();
            ItemComponetInit();
        }
    }
    public void ItemTypeInitalize(int Type)
    {

        switch (Type)
        {
            case 0:
                {
                    Debug.Log("타입은 무기");
                    break;
                }
            case 1:
                {
                    Debug.Log("타입은 방어구");
                    break;
                }
        }

        id = 0;
        //m_Name = "SimpleName";
        m_Story = "테스트용 스토리";
        m_Atk = 10;
        m_Def = 3;
        m_Speed = 1;

    }

    public void SetItem(Item target)
    {
        id = target.id;
        switch (target.part)
        {
            case GameManager.e_Itemtype.헬멧:
                part = GameManager.e_Itemtype.헬멧;
                break;
            case GameManager.e_Itemtype.무기:
                part = GameManager.e_Itemtype.무기;
                break;
            case GameManager.e_Itemtype.방어구:
                part = GameManager.e_Itemtype.방어구;
                break;
            case GameManager.e_Itemtype.장신구:
                part = GameManager.e_Itemtype.장신구;
                break;
        }

        //m_Name = target.m_Name;
        m_Story = target.m_Story;
        price = target.price;
        m_Atk = target.m_Atk;
        m_Def = target.m_Def;
        m_Speed = target.m_Speed;
    }


    public void ShowItemStaturs()
    {
        if(ItemImg.sprite ==null)
        {
            Debug.LogWarning("ItemImg가 지정되어있지않습니다");
            return;
        }
        GameManager.instance.Sp_ItemImg.sprite = this.ItemImg.sprite;


        GameManager.instance.Sp_ItemNameText.text = this.ItemNameText.text;
        GameManager.instance.Sp_ItemStoryText.text = this.m_Story;
        GameManager.instance.target = this.gameObject;
    }



}

