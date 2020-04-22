using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData
{
    [Header("item")]
    public int id;
    public string name;
    public int price;
    public string m_Story;
    public int m_Atk;
    public int m_Def;
    public float m_Speed;
    public GameManager.e_Itemtype Type;
    public Sprite ItemImg;

    public ItemData(
        int _id, 
        int _itemtype,
        Sprite _img,
        string _name,
        string _stroy,
        int _pri,
        int _atk,
        int _def,
        float _speed)


    {
        id = _id;
        switch (_itemtype)
        {
            case 0:
                Type = GameManager.e_Itemtype.헬멧;
                break;
            case 1:
                Type = GameManager.e_Itemtype.무기;
                break;
            case 2:
                Type = GameManager.e_Itemtype.방어구;
                break;
            case 3:
                Type = GameManager.e_Itemtype.장신구;
                break;
        }
        ItemImg = _img;
        name = _name;
        m_Story = _stroy;
        price = _pri;
        m_Atk = _atk;
        m_Def = _def;
        m_Speed = _speed;
    }

}
    


