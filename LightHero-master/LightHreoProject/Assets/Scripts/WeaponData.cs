using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponData : Item
{
    public float leanth;
    public Sprite buletImg;

    public WeaponData(int _id, int _itemtype, int _rank, int _series, Sprite _img, string _name, string _stroy, int _pri, int _atk, int _def, float _speed,float _leangth, Sprite _bulet) : base(_id, _itemtype, _rank, _series, _img, _name, _stroy, _pri, _atk, _def, _speed)
    {
        id = base.id;
        Type = base.Type;
        rank = base.rank;
        series = base.series;
        ItemImg = base.ItemImg;
        name = base.name;
        m_Story = base.m_Story;
        price = base.price;
        m_Atk = base.m_Atk;
        m_Def = base.m_Def;
        m_Speed = base.m_Speed;
        leanth = _leangth;
        buletImg = _bulet; 
        //게임상에서 나라가는 오브젝트 이미지
    }
}
