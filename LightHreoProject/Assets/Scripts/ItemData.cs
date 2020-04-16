using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    [Header("item")]
    public int id;
    public int price;
    public string m_Story;
    public float m_Atk;
    public float m_Def;
    public float m_Speed;
    public GameManager.e_Itemtype part;

    public ItemData(int _id, int _itemtype, string _name, string _stroy, int _pri, float _atk, float _def, float _speed)
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

    public void GetItemDatas(GameObject target , int id)
    {
        Item result = null;
        target.GetComponent<Item>().SetItem(result);
    }
}
    


