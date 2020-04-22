using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase
{
    public object[] sprites;
    public List<string> itemList = new List<string>();

    public Dictionary<int, ItemData> dic_item = new Dictionary<int, ItemData>();

    private static DataBase instance;

    public static DataBase getInstance()
    {
        if(instance == null)
        {
            instance = new DataBase();
        }
        return instance;
    }

    public Sprite ScerchImg(string str_name)
    {
      
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i].ToString()  == (str_name + " (UnityEngine.Sprite)"))
            {
                return sprites[i] as Sprite;
            }
        }
        return null;
    }

    //case 0: part = GameManager.e_Itemtype.헬멧;
    //case 1: part = GameManager.e_Itemtype.무기;
    //case 2:part = GameManager.e_Itemtype.방어구;
    //case 3: part = GameManager.e_Itemtype.장신구;

    public void ItemListCall()
    {
        sprites = Resources.LoadAll("Image/item");
        itemList.Add("0,3,kindpng_283192_1,신속의링,이동이 빨라졌다,4000,0,0,0.5");
        itemList.Add("1,1,kindpng_283192_70,단검,단순한 단검이다,1000,2,0,0");
        itemList.Add("2,0,kindpng_283192_78,헬멧,단순한 헬멧이다,1400,0,10,0");
        itemList.Add("3,0,kindpng_283192_84,좋은 헬멧,좋은 헬멧이다,2500,0,20,0");
        itemList.Add("4,2,kindpng_283192_85,갑옷,단순한 갑옷이다,2500,0,20,0");
        itemList.Add("5,1,kindpng_283192_72,장검,좋은 장검이다,2400,9,0,0");
        itemList.Add("6,3,kindpng_283192_97,기술의 비서,비기가 적혀있는 비술서다,2000,4,0,0");
        itemList.Add("7,1,kindpng_283192_100,방출의 마법봉,힘이 빠지는 마법봉이다,2000,7,-3,0");
        itemList.Add("8,2,kindpng_283192_93,검은 장화,이동 속도를 올려준다,2000,0,2,0.3");
        itemList.Add("9,3,kindpng_283192_70,신속의 반지,단순한 검이다,2000,10,0,0");

    }



  

}

