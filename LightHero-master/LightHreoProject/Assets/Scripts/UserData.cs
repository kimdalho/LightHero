using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LitJson;
using System.IO;
using TMPro;
public class UserData 
{
    /*#######################################################
    내가가지고 있는 아이템의 랭크가 무엇이다 를 알려줄 필요가 있다
    #########################################################
    
    계획 우선 내가 세이브를 하고 난뒤

    내가 가지고있는 아이템의 곗수를 확인한다 1개든 10개든

    확인뒤 내가 가지고있는 아이템을 차례대로 랭크를 확인한다 (별자리가 무엇인지도 확인을 해야할지는 아직 가늠이 안됨)

    확인을 했다면 그 정보를 저장한다 주의해야할점은 대상 아이템과 대상 랭크를 정확히 확인하고 불러올수있는 로직을 구성해야한다
   

   
    ########################################################*/

    private static UserData instance;

    public static UserData getInstance()
    {
        if (instance == null)
        {
            instance = new UserData();
        }
        return instance;
    }
    public List<SaveData> InvenItemList = new List<SaveData>();

    //여기로부터 값은 초기화가 된다
    public List<SaveData> slotList = new List<SaveData>(new List<SaveData> {new SaveData(), new SaveData(), new SaveData(), new SaveData() });


    public Dictionary<string, List<int>> userDatas
    = new Dictionary<string, List<int>>();

    public Dictionary<string,object> index
    = new Dictionary<string, object>();

    public void ShowBuyItemList()
    {
        for(int i = 0; i < InvenItemList.Count;i++)
        {
            Debug.Log(DataBase.getInstance().GetItem[0][i].id);
        }
    }

    public int      m_money;
    public int      m_atack;
    public int      m_defenc;
    public float    m_speed;

    public int SetUserAttack(int valuse)    {m_atack += valuse;     return m_atack;}
    public int SetUserDefence(int valuse)   { m_defenc += valuse; return m_defenc; }
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
      
        index["Money"] = m_money;
        index["InvenList"] = InvenItemList;
        index["UsingItemList"] = slotList;
        SaveData();
    }

    public string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public T JsonToOject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
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
      
        index["Money"] = m_money;
        index["InvenList"] = InvenItemList;
        index["UsingItemList"] = slotList;

        JsonData ItemJson = JsonMapper.ToJson(index);
        SaveData(str);
    }

    public void SaveData(string str)
    {
            JsonData ItemJson = JsonMapper.ToJson(index);
            File.WriteAllText(str, ItemJson.ToString());
        
    }


   
}
