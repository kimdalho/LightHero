using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LitJson;
using System.IO;
using TMPro;
public class UserData
{

    private static UserData instance;

    public static UserData getInstance()
    {
        if (instance == null)
        {
            instance = new UserData();
        }
        return instance;
    }
    public List<int> BuyItemList = new List<int>();
    public List<int> userEqList = new List<int>(new int[] { -1,-1,-1,-1 });

    public Dictionary<string, List<int>> userDatas
    = new Dictionary<string, List<int>>();

    public Dictionary<string,object> index
    = new Dictionary<string, object>();

    public void ShowBuyItemList()
    {
        for(int i = 0; i < BuyItemList.Count;i++)
        {
            Debug.Log(DataBase.getInstance().dic_item[i].name);
        }
    }

    public int      m_money;
    public int      m_atack;
    public int      m_defenc;
    public float    m_speed;

   public int SetUserAttack(int valuse) {m_atack += valuse;     return m_atack;}
   public int SetUserDefence(int valuse) { m_defenc += valuse; return m_defenc; }
   public float SetUserSpeed(float valuse) { m_speed += valuse; return m_speed; }
   public void AddMoney(int valuse)
    {
         this.m_money += valuse;
         GameManager.getInstance().Tmp_money.GetComponent<TextMeshProUGUI>().text = m_money.ToString();
    }
   public void UserMoneyStatuersUpdate()
    {
        GameManager.getInstance().Tmp_money.GetComponent<TextMeshProUGUI>().text = m_money.ToString();
    }

    public void AllWirteUserData()
    {
        index["monry"] = m_money;
        index["buyList"] = BuyItemList;
        index["EqList"] = userEqList;
        JsonData ItemJson = JsonMapper.ToJson(index);
        SaveData();
    }

    public void SaveData()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            JsonData ItemJson = JsonMapper.ToJson(index);
            File.WriteAllText(Application.persistentDataPath + "/UserItemData", ItemJson.ToString());
        }
        else
        {
            JsonData ItemJson = JsonMapper.ToJson(index);
            File.WriteAllText(Application.dataPath + "/UserItemData", ItemJson.ToString());
        }
    }



    public void AllWirteUserData(string str)
    {
        index["monry"] = m_money;
        index["buyList"] = BuyItemList;
        index["EqList"] = userEqList;
        JsonData ItemJson = JsonMapper.ToJson(index);
        SaveData(str);
    }

    public void SaveData(string str)
    {
            JsonData ItemJson = JsonMapper.ToJson(index);
            File.WriteAllText(str, ItemJson.ToString());
        
    }

}
