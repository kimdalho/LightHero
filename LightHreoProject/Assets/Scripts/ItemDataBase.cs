using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase
{

    public List<string> itemList = new List<string>();
    public Dictionary<int, ItemData> dic_item = new Dictionary<int, ItemData>();

    //case 0: part = GameManager.e_Itemtype.헬멧;
    //case 1: part = GameManager.e_Itemtype.무기;
    //case 2:part = GameManager.e_Itemtype.방어구;
    //case 3: part = GameManager.e_Itemtype.장신구;

    private static ItemDataBase instance;

    public static ItemDataBase getInstance()
    {
        if(instance == null)
        {
            instance = new ItemDataBase();
           
        }
        return instance;
    }

    public void ItemListCall()
    {
        itemList.Add("0,1,검,단순한 검이다,1000,10,0,0");
        itemList.Add("1,2,방패,단순한 방패다,1000,0,0,0");
        itemList.Add("2,2,갑옷,단순한 갑옷이다,500,0,10,0");
        itemList.Add("3,3,반지,단순한 반지다,1000,0,0,0.5");
        itemList.Add("4,1,장검,단순한 장검이다,2000,14,0,0");
        itemList.Add("5,2,철갑옷,단순한 철갑옷이다,2000,0,0,0");
        itemList.Add("6,3,신속의 반지,단순한 검이다,2000,10,0,0");
        itemList.Add("6,3,신속의 반지,단순한 검이다,2000,10,0,0");
        itemList.Add("6,3,신속의 반지,단순한 검이다,2000,10,0,0");
        itemList.Add("6,3,신속의 반지,단순한 검이다,2000,10,0,0");
    }



  

}

