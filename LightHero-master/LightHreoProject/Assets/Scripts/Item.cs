using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    [Header("item")]
    public int id;
    public string name;
    public int rank;
    public int series;
    public int price;
    public string m_Story;
    public int m_Atk;
    public int m_Def;
    public float m_Speed;
    public int Type;
    public Sprite ItemImg;


    //게임상에서 나라가는 오브젝트 이미지

    /*****************
    투사체 변수 
    등급 추가  ok
    세트넘버 추가 ok
    *****************/

    /*****Rank*******
           D
           C
           B
           A
           S
    ******Rank*******/

    /*****Series******
         0
         1
         2
         3
         4
         5
         6
         7
         8
         9
         10
         11
   ******Series*******/

    public Item
        (
        int _id,        //아이디
        int _itemtype,  //아이템 타입
        int _rank,   //랭크
        int _series,    //시리즈
        Sprite _img,    //이미지
        string _name,   //이름
        string _stroy,  //스토리
        int _pri,       //가격
        int _atk,       //공격력
        int _def,       //방어력
        float _speed
        )   


    {
        id = _id;
        Type = _itemtype;
        rank = _rank;
        ItemImg = _img;
        name = _name;
        m_Story = _stroy;
        price = _pri;
        m_Atk = _atk;
        m_Def = _def;
        m_Speed = _speed;
    }


    public Item ToItem
         (

        )


    {
        Item obj = new Item(id, Type, rank, series, ItemImg, name, m_Story, price, m_Atk, m_Def, m_Speed);

        return obj;

    }

  
}
    


