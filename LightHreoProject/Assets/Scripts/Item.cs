using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    int id;
    int price;
    int type;
    string  m_Name;
    string  m_Story;
    float   m_Atk;
    float   m_Def;
    float   m_Speed;

    Button bnt;

    public Item()
    {

    }

    private void Start()
    {
        bnt = GetComponentInChildren<Button>();
        bnt.onClick.AddListener(Buy);
    }

    public Item(int Type)
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
        m_Name = "SimpleName";
        m_Story = "테스트용 스토리";
        m_Atk = 10;
        m_Def = 3;
        m_Speed = 1;

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
        m_Name = "SimpleName";
        m_Story = "테스트용 스토리";
        m_Atk = 10;
        m_Def = 3;
        m_Speed = 1;

        }

    public void Buy()
    {
        GameManager.instance.Add_Money(-price);
    }

}
