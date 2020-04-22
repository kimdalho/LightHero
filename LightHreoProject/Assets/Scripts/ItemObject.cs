using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemObject : MonoBehaviour
{

    [Header("item")]
    public int id;
    public void ItemComponetInit()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            string compo_name = gameObject.transform.GetChild(i).name;
            switch (compo_name)
            {
                case "ItemImg":
                    gameObject.transform.GetChild(i).GetComponent<Image>().sprite 
                        = DataBase.getInstance().dic_item[this.id].ItemImg;
                    break;

                case "ItemNameText":
                   gameObject.transform.GetChild(i).GetComponent<Text>().text = 
                        DataBase.getInstance().dic_item[this.id].name;

                    break;
            }
        }
    }

    public void ShowItemStaturs()
    {
        ItemData target = DataBase.getInstance().dic_item[this.id];
        GameManager.getInstance().Sp_ItemImg.sprite =     target.ItemImg;
        GameManager.getInstance().Sp_ItemNameText.text =  target.name;
        GameManager.getInstance().Sp_ItemStoryText.text = target.m_Story;

        GameManager.getInstance().PrdcPriceText.text  = "Money: " + target.price.ToString();
        GameManager.getInstance().PrdcAtkText.text    = "Atack: " + target.m_Atk.ToString();
        GameManager.getInstance(). PrdcDefText.text   = "Defenc: " + target.m_Def.ToString();
        GameManager.getInstance().PrdcSpeedText.text  = "Speed: " + target.m_Speed.ToString();

       GameManager.getInstance().using_Target = this.gameObject;
    }
}

