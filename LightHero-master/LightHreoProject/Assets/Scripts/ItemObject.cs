using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemObject : MonoBehaviour
{

    [Header("item")]
    public int id;
    public int numbering;
    public int type;
    public int rank;
    public int constellation;

    public void ItemComponetInit(int index,int number)
    {
        /*################################################################
        예외처리 타입은 0~3까지 출력된다 때문에 인덱스를 벗어나지않게 지정한다
        ################################################################*/
        if (index != 1)
        {
            index = 0;
        }
        /*################################################################
        예외처리 타입은 0~3까지 출력된다 때문에 인덱스를 벗어나지않게 지정한다
        ################################################################*/
        GameObject itemimgBuffer = null;
        Sprite img = null;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            string compo_name = gameObject.transform.GetChild(i).name;

            switch (compo_name)
            {
                case "ItemImg":
                    itemimgBuffer = gameObject.transform.GetChild(i).gameObject;

                    gameObject.transform.GetChild(i).GetComponent<Image>().sprite 
                        = DataBase.getInstance().GetItem[index][number].ItemImg;
                    break;

                case "ItemNameText":
                   gameObject.transform.GetChild(i).GetComponent<Text>().text = 
                        DataBase.getInstance().GetItem[index][number].name;

                    break;
            }
        }
      
        
        for(int i = 0; i < itemimgBuffer.transform.childCount; i++)
        {
            string compo_name = itemimgBuffer.transform.GetChild(i).name;
            int rank = -1;
            int constellation = -1;
            switch(compo_name)
            {
                case "Rankimg": //디스플레이 아이템 이미지 지정
                    rank = DataBase.getInstance().GetItem[index][number].rank;
                    img = DataBase.getInstance().GetSng[0][rank].img;
                    itemimgBuffer.transform.GetChild(i).GetComponent<Image>().sprite = img;
                    break;
                case "SceriseImg":
                    constellation = DataBase.getInstance().GetItem[index][number].series;
                    img = DataBase.getInstance().GetSng[1][constellation].img;
                    itemimgBuffer.transform.GetChild(i).GetComponent<Image>().sprite = img;
                    break;
            }
        }
    }
    public void ShowItemStaturs() //버튼
    {
        int index = 1;
        if(this.type != 1)
        {
            index = 0;
        }
        Item target = DataBase.getInstance().GetItem[index][this.id];

       GameManager.getInstance().using_Target = this.gameObject;
       if (GameManager.getInstance().staturs == GameManager.e_Panel.인벤창)
       {
           GameManager.getInstance().Use();
           GameManager.getInstance().ShowAttack();
           GameManager.getInstance().ShowDefenc();
           GameManager.getInstance().ShowSpeed();
        }
       else if(GameManager.getInstance().staturs == GameManager.e_Panel.상점)
       {
            GameManager.getInstance().Sp_ItemImg.sprite = target.ItemImg;
            GameManager.getInstance().Sp_ItemRankText.text = target.rank.ToString();
            GameManager.getInstance().Sp_ItemSeriesText.text = target.series.ToString();
            GameManager.getInstance().Sp_ItemNameText.text = target.name;
            GameManager.getInstance().Sp_ItemStoryText.text = target.m_Story;

            GameManager.getInstance().PrdcPriceText.text = "Money: " + target.price.ToString();
            GameManager.getInstance().PrdcAtkText.text = "Atack: " + target.m_Atk.ToString();
            GameManager.getInstance().PrdcDefText.text = "Defenc: " + target.m_Def.ToString();
            GameManager.getInstance().PrdcSpeedText.text = "Speed: " + target.m_Speed.ToString();

            


        }

    }

    public ItemObject()
    {
        id = -1;
        numbering =-1;
        type =-1;
        rank =-1;
        constellation = -1;
    }
    
}

