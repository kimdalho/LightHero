using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LitJson;
using System.IO;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class GameBord : MonoBehaviour
{

   // GameObject 


    public GameObject itemPrefab;
    public Image[] itemicons = new Image[4];
 

    private void Start()
    {
        GameManager.getInstance().GameSetting();
        DisplayItem();
        GameManager.getInstance().SetMoney(100000);
        LoadInven();
        //GameManager.getInstance().LoadData();




    }




    public void DisplayItem()
    {
        if (itemPrefab == null)
        {
            Debug.LogError("itemPrefab 비어있다");
            return;
        }
        if (GameManager.getInstance().ShopContent == null)
        {
            Debug.LogError("ShopContent 비어있다");
            return;
        }

        
        //인덱스
        for (int index = 0; index < DataBase.getInstance().GetItem.Count; index++) // 0~1
        {
            //인덱스 종류 반복시킨다
            for(int i = 0; i< DataBase.getInstance().GetItem[index].Count; i++) //[0]~n , [1]~n
            {
                
                GameObject product = Instantiate(itemPrefab);
                product.name = "item";

                product.GetComponent<ItemObject>().id = DataBase.getInstance().GetItem[index][i].id;                //아이디
                product.GetComponent<ItemObject>().type = index;                                                    //타입
                product.GetComponent<ItemObject>().rank = DataBase.getInstance().GetItem[index][i].rank;            //랭크
                product.GetComponent<ItemObject>().constellation = DataBase.getInstance().GetItem[index][i].series; //별자리

                product.GetComponent<ItemObject>().ItemComponetInit(index,i);
                product.transform.SetParent(GameManager.getInstance().ShopContent.transform);
                product.transform.localScale = new Vector3(1, 1, 1);
            }

           
        }
    }


    public void Buy()
    {
        if (GameManager.getInstance().using_Target == null) return;
        ItemObject item = GameManager.getInstance().using_Target.GetComponent<ItemObject>();
        //#################머니 비교 #######################
        if (DataBase.getInstance().GetItem[0][item.id].price > UserData.getInstance().m_money)
        {
            GameManager.getInstance().Sp_ItemStoryText.text = "소지 골드가 부족합니다";
            return;
        }

        else
        {
            GameManager.getInstance().AddMoney(-DataBase.getInstance().GetItem[0][item.id].price);

            //#################대상 아이템 인벤 생성 #######################
            GameObject product;
            product = Instantiate(GameManager.getInstance().using_Target);
            product.transform.SetParent(GameManager.getInstance().InventoryContent.transform);
            product.transform.localScale = new Vector3(1, 1, 1);
            //#################대상 아이템 인벤 생성 #######################

            //케스팅


            //#################대상 UserData List추가 #######################
            UserData.getInstance().InvenItemList.Add(new SaveData(
            item.id,                                                    //아이디
            UserData.getInstance().InvenItemList.Count,                 //넘버링
            DataBase.getInstance().GetItem[item.type][item.id].Type,    //타입
            DataBase.getInstance().GetItem[item.type][item.id].rank,    //랭크
            DataBase.getInstance().GetItem[item.type][item.id].series   //별자리
            ));
            product.GetComponent<ItemObject>().numbering = UserData.getInstance().InvenItemList.Count;


            UserData.getInstance().AllWirteUserData();
            GameManager.getInstance().using_Target = null;
            //#################대상 UserData List추가 #######################
        }
        HideBuyMessage();
    }

    public void ShowBuyMessage()
    {
        GameManager.getInstance().panels[(int)GameManager.e_Panel.Message].SetActive(true);
    }
    public void HideBuyMessage()
    {
        GameManager.getInstance().panels[(int)GameManager.e_Panel.Message].SetActive(false);
    }


    public void LoadInven()
    {
        if (GameManager.getInstance().Findfile(Application.dataPath + "/UserItemData"))
        {
            string Jsonstring = File.ReadAllText(Application.dataPath + "/UserItemData");
            JsonData userdata = JsonMapper.ToObject(Jsonstring);
          
            //#########################################################################################
            for (int i = 0; i < userdata[1].Count; i++)
            {
                GameObject obj = Instantiate(itemPrefab) as GameObject;
                obj.transform.SetParent(GameManager.getInstance().InventoryContent.transform);
                obj.transform.localScale = new Vector3(1,1,1);
                ItemObject myitem = obj.GetComponent<ItemObject>();
                myitem.id               = int.Parse( userdata[1][i]["id"].ToString());
                myitem.numbering        = int.Parse(userdata[1][i]["number_id"].ToString());
                myitem.type             = int.Parse(userdata[1][i]["itemtype"].ToString());
                myitem.rank             = int.Parse(userdata[1][i]["rank"].ToString());
                myitem.constellation    = int.Parse(userdata[1][i]["constellation"].ToString());
                myitem.ItemComponetInit(myitem.type, myitem.id);

                int index = GameManager.getInstance().IndexReder(myitem.type);

                //#################대상 UserData List추가 #######################
                UserData.getInstance().InvenItemList.Add(new SaveData(
                myitem.id,                                                      //아이디
                myitem.numbering,                                               //넘버링
                DataBase.getInstance().GetItem[index][myitem.id].Type,          //타입
                DataBase.getInstance().GetItem[index][myitem.id].rank,          //랭크
                DataBase.getInstance().GetItem[index][myitem.id].series         //별자리
                ));
                UserData.getInstance().AllWirteUserData();
                //#################대상 UserData List추가 #######################
            }
                //########################################################################################



        }
    }

    public void LoadUsingItem()
    {
        if (GameManager.getInstance().Findfile(Application.dataPath + "/UserItemData"))
        {
            string Jsonstring = File.ReadAllText(Application.dataPath + "/UserItemData");
            JsonData userdata = JsonMapper.ToObject(Jsonstring);

            for (int i = 0; i < userdata[2].Count; i++)
            {

            }
        }
    }

}
