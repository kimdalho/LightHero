using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using LitJson;
using System.IO;
using UnityEngine.Android;
public class GameManager 
{
   
    public enum e_Itemtype
    {
        헬멧 = 0,
        무기 = 1,
        방어구 = 2,
        장신구 = 3,
    }
    #region 변수선언

    

    [Header("CanversPanels")]
    
    public GameObject ButtonPanel;
    public GameObject LoginPanel;
    public GameObject[] panels = new GameObject[7];
    public InputField nickNameInput;
    public enum e_Panel
    {
        커넥션 = 0, // DisconnectPanel
        상점 = 1, // ShopPanel
        인벤창 = 2, // InvenPanel
        로비 = 3, // LobbyPanel
        상태창 = 4, // PlayerStatursPanel
        융합 = 5, // PlayerStatursPanel
        Message = 6
    }
    public e_Panel staturs;
    public GameObject ConnectBtn;
    public GameObject NickNameLabel;
    [Header("LobbyPanel")]
    public TMP_InputField roomInput;
    public Text WelcomeText;
    public Text LobbyInfoText;
    public Button[] CellBtn;
    public Button NextBtn;
    public Button PreviousBtn;
    [Header("PlayerStaturs")]
    public TextMeshProUGUI Tmp_money;
    public TextMeshProUGUI Tmp_Attack;
    public TextMeshProUGUI Tmp_Defenc;
    public TextMeshProUGUI Tmp_Speed;
    [Header("InventoryPanel")]
    public GameObject[] m_EquipSlot = new GameObject[4];
    [Header("ItemShopPanel")]
    public Image ItemdescriptionPanel;
    public Image Story_Panel;
    public GameObject ShopContent;
    public GameObject ItemBuyBtn;
    public Text Sp_ItemNameText;
    public Text Sp_ItemRankText;
    public Text Sp_ItemSeriesText;
    public Image Sp_ItemImg;
    public Text Sp_ItemStoryText;

    [Header("staysters")]
    public Text PrdcPriceText;
    public Text PrdcAtkText;
    public Text PrdcDefText;
    public Text PrdcSpeedText;

    [Header("Member variable")]
    public GameObject Btn_WallController;
    public int Filed_MonsterCount;
    public bool MoveMod;
    public TouchScreenKeyboard keyboard { get; private set; }
    #endregion
    #region GetterORSetter
    public int Getm_money()
    {
        return UserData.getInstance().m_money;
    }
    public int SetMoney(int addm_money)
    {
        UserData.getInstance().m_money = addm_money;
        Tmp_money.text = UserData.getInstance().m_money.ToString();
        return UserData.getInstance().m_money;
    }
    public void SetAttack(int value)
    {
        UserData.getInstance().m_atack = value;
    
    }
    public int SetDefenc(int value)
    {
        UserData.getInstance().m_defenc = value;
      //  Tmp_Defenc.text = UserData.getInstance().m_defenc.ToString();
        return UserData.getInstance().m_defenc;
    }
    public float SetSpeed(float value)
    {
        UserData.getInstance().m_speed = value;


        return UserData.getInstance().m_speed;
    }

    public void AddMoney(int value)
    {
        UserData.getInstance().m_money += value;
        Tmp_money .GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_money.ToString();

    }
    public void AddAttack(int value)
    {
        UserData.getInstance().m_atack += value;
        Tmp_Attack.GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_atack.ToString();

    }
    public int AddDefenc(int value)
    {
        UserData.getInstance().m_defenc += value;
        Tmp_Defenc.GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_defenc.ToString();
        return UserData.getInstance().m_defenc;
    }
    public float AddSpeed(float value)
    {
        UserData.getInstance().m_speed += value;

        Tmp_Speed.GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_speed.ToString();
        return UserData.getInstance().m_speed;
    }

    public void ShowMoney()
    {
        Tmp_money.text = UserData.getInstance().m_atack.ToString();
    }

    public void ShowAttack()
    {
        Tmp_Attack.text = UserData.getInstance().m_atack.ToString();
    }

    public void ShowDefenc()
    {
       Tmp_Defenc.text = UserData.getInstance().m_atack.ToString();
    }

    public void ShowSpeed()
    {
        Tmp_Speed.text = UserData.getInstance().m_speed.ToString();
    }

    #endregion
    #region Event
    private static GameManager instance;

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }
    public bool OnRendering_Items = false;
    public void GameSetting()
    {
            Application.targetFrameRate = 30;
            MainCanversInitalize();

        if (OnRendering_Items == true)
        {
            //Connect();
            SwichpanelsView(e_Panel.커넥션);
            return;
        }

        else
        {
            //############여긴 한번만###########

            DataBase.getInstance().ItemDataSetUp(); 
            


      
            //###########여긴 한번만###############
            OnRendering_Items = true;
            SwichpanelsView(e_Panel.커넥션);
            //   SetMoney(99999);
        }
        
        if (Btn_WallController == null)
                return;
        
    }
    #endregion
    public void LoadPanel(int valsue)
    {
        SwichpanelsView((e_Panel)valsue);
    }
    #region 메인커넥션
    private void MainCanversInitalize()
    {
        if (GameObject.Find("MainCanvers") == null)
        {
            return;
        }

        GameObject mainCvs = GameObject.Find("MainCanvers");

        for (int i = 0; i < mainCvs.transform.childCount; i++)
        {
            string compo_name = mainCvs.transform.GetChild(i).name;
            switch (compo_name)
            {
                case "GoldImg":
                    {
                        GameObject img = mainCvs.transform.GetChild(i).gameObject;
                        Tmp_money = img.transform.GetComponentInChildren<TextMeshProUGUI>();
                        break;
                    }
                case "ShopPanel":
                    panels[(int)e_Panel.상점] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "InvenPanel":
                    panels[(int)e_Panel.인벤창] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "LobbyPanel":
                    panels[(int)e_Panel.로비] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "FusePanel":
                    panels[(int)e_Panel.융합] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "MessagePanel":
                    panels[(int)e_Panel.Message] = mainCvs.transform.GetChild(i).gameObject;
                    break;

            }
        }

        ShopPanelInitalize();

        DescriptionInitalize();

        LobbyPanelInitalize();

        InventoryPanelInitalize();

        PlayerStatursInitalize();

        EquipItemPanelInitalize();

        ShopPanelInit();

        MessagePanelInitalize();

        // SwichpanelsView(e_Panel.커넥션);
    }

    public void MessagePanelInitalize()
    {
        panels[(int)e_Panel.Message].SetActive(false);
    }

    public void DescriptionInitalize()
    {
        //public Image ItemdescriptionPanel;
        //public Image Story_Panel;
        //public Text Sp_ItemName;
        //public Image Sp_ItemImg;
        //public Text Sp_ItemStoryText;
        //GameObject    TgItemStatursPanel
        GameObject TgItemStatursPanel = null;

        for (int i = 0; i < ItemdescriptionPanel.transform.childCount; i++)
        {
            string compo_name = ItemdescriptionPanel.transform.GetChild(i).name;

            switch (compo_name)
            {

                case "Story_Panel":
                    Story_Panel = ItemdescriptionPanel.transform.GetChild(i).gameObject.GetComponent<Image>();
                    break;

                case "TgItemStatursPanel":
                    TgItemStatursPanel = ItemdescriptionPanel.transform.GetChild(i).gameObject;
                    break;

                case "ItemBuyBtn":
                    ItemBuyBtn = ItemdescriptionPanel.transform.GetChild(i).gameObject;
                    break;



            }

        }

        for (int i = 0; i < TgItemStatursPanel.transform.childCount; i++)
        {
            string compo_name = TgItemStatursPanel.transform.GetChild(i).name;

            switch (compo_name)
            {

                case "PrdcPriceText":
                    PrdcPriceText = TgItemStatursPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "PrdcAtkText":
                    PrdcAtkText = TgItemStatursPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "PrdcDefText":
                    PrdcDefText = TgItemStatursPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "PrdcSpeedText":
                    PrdcSpeedText = TgItemStatursPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
            }
        }

        for (int i = 0; i < Story_Panel.transform.childCount; i++)
        {
            string compo_name = Story_Panel.transform.GetChild(i).name;

            switch (compo_name)
            {

                case "Sp_ItemNameText":
                    Sp_ItemNameText = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "Sp_ItemRankText":
                    Sp_ItemRankText = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "Sp_ItemSeriesText":
                    Sp_ItemSeriesText = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "Sp_ItemImg":
                    Sp_ItemImg = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Image>();
                    break;
                case "Sp_ItemStoryText":
                    Sp_ItemStoryText = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
            }
        }


    }
    public void ShopPanelInitalize()
    {
        for(int i = 0; i < panels[(int)e_Panel.상점].transform.childCount;i++)
        {
            string compo_name = panels[(int)e_Panel.상점].transform.GetChild(i).name;

            switch (compo_name)
            {
                case "ItemdescriptionPanel":
                    ItemdescriptionPanel = panels[(int)e_Panel.상점].transform.GetChild(i).GetComponent<Image>();
                    break;
            }
        }
    }
    public void SwichpanelsView(e_Panel target_panels)
    {
        this.staturs = target_panels;
        switch (staturs)
        {
            case e_Panel.커넥션:
                {
                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(false);
                    panels[(int)e_Panel.융합].SetActive(false);
                    ItemdescriptionPanel.gameObject.SetActive(false);
                    break;
                }
            case e_Panel.상점:
                {
                    
                    panels[(int)e_Panel.상점].SetActive(true);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(false);
                    panels[(int)e_Panel.융합].SetActive(false);
                    ItemdescriptionPanel.gameObject.SetActive(true);
                    ItemBuyBtn.SetActive(true);
                    break;
                }
            case e_Panel.인벤창:
                {
                  
                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(true);
                    panels[(int)e_Panel.로비].SetActive(false);
                    panels[(int)e_Panel.융합].SetActive(false);
                    ItemdescriptionPanel.gameObject.SetActive(false);
                    ShowAttack();
                    ShowDefenc();
                    ShowSpeed();

                    
                    break;
                }
            case e_Panel.로비:
                {
                  
                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(true);
                    panels[(int)e_Panel.융합].SetActive(false);
                    ItemdescriptionPanel.gameObject.SetActive(false);

                    break;
                }
            case e_Panel.융합:
                {

                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(false);
                    panels[(int)e_Panel.융합].SetActive(true);
                    ItemdescriptionPanel.gameObject.SetActive(false);

                    break;
                }
            default: {
                    Debug.LogWarning("SwichpanelsView에 지정되어있지않은 상태가 출력되었습니다");
                    break;
                }


        }
    }
    public void Connect()
    {
        LoginPanel.SetActive(false);
        ButtonPanel.SetActive(true);
        
    }
    #endregion
    #region 디스커넥션


    #endregion
    #region 상점

    public void ShopPanelInit()
    {
        ShopContent = GameObject.Find("ShopContent");
    }
    #endregion
    #region 인벤토리

    public GameObject InventoryContent;
    public GameObject UserPanel;
    public GameObject SetPanel;
    //################### 정말 비효율적 소스#####################################
    public Dictionary<string, GameObject> instancdic = new Dictionary<string, GameObject>();
    GameObject S;
    GameObject R;
    //################### 정말 비효율적 소스#####################################
    private void InventoryPanelInitalize()
    {

        for(int i = 0; i< panels[(int)e_Panel.인벤창].transform.childCount;i++)
        {
            string compo_name = panels[(int)e_Panel.인벤창].transform.GetChild(i).name;
            
            switch(compo_name)
            {
                case "UserPanel":
                    UserPanel = panels[(int)e_Panel.인벤창].transform.GetChild(i).gameObject;
                    break;
            }

        }




        InventoryContent = GameObject.Find("InventoryContent");

        for(int i = 0;i < UserPanel.transform.childCount; i++)
        {
            string compo_name = UserPanel.transform.GetChild(i).name;
            switch(compo_name)
            {
                case   "PlayerStatursPanel":
                    panels[(int)e_Panel.상태창] = UserPanel.transform.GetChild(i).gameObject;
                break;
                case "SetPanel":
                    SetPanel = UserPanel.transform.GetChild(i).gameObject;
                    break;
            }
        }
        //################### 정말 비효율적 소스#####################################
        
       S = ScerchObject(SetPanel, "RankActionPanel");

       R = ScerchObject(SetPanel, "SerisActionPanel");

        instancdic.Add("SList", S);
        instancdic.Add("RList", R);

        instancdic.Add("Rimg", ScerchObject(instancdic["RList"], "Icon_bkImg"));
        instancdic.Add("RName", ScerchObject(instancdic["RList"], "SetNameText"));
        instancdic.Add("RAction", ScerchObject(instancdic["RList"], "SetActionText"));


        instancdic.Add("Simg", ScerchObject(instancdic["SList"], "Icon_bkImg"));
        instancdic.Add("SName", ScerchObject(instancdic["SList"], "SetNameText"));
        instancdic.Add("SAction", ScerchObject(instancdic["SList"], "SetActionText"));

        //Debug.Log("존재 확인1" + GameManager.getInstance().instancdic["SName"].name);
        //################### 정말 비효율적 소스#####################################
    }

    public GameObject ScerchObject(GameObject parent, string Name)
    {
        GameObject result = null;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            string compo_name = parent.transform.GetChild(i).name;
            if(compo_name == Name)
            {
                result = parent.transform.GetChild(i).gameObject;
            }
        }
        return result;
    }


    #endregion
    #region 로비
    private void LobbyPanelInitalize() //// MainCanversInitalize()에서 호출 사용 다른곳에서 사용x
    {
        GameObject RoomControllPanel = null;
        for (int i = 0; i < panels[(int)e_Panel.로비].transform.childCount; i++)
        {
            string compo_name = panels[(int)e_Panel.로비].transform.GetChild(i).name;

            switch (compo_name)
            {
                case "RoomControllPanel":
                    RoomControllPanel = panels[(int)e_Panel.로비].transform.GetChild(i).gameObject;
                    break;
                case "WelcomeText":
                    WelcomeText = panels[(int)e_Panel.로비].transform.GetChild(i).gameObject.GetComponent<Text>();
                    break;
                case "LobbyInfoText":
                    LobbyInfoText = panels[(int)e_Panel.로비].transform.GetChild(i).gameObject.GetComponent<Text>(); ;
                    break;
            }
        }
    }
    #endregion
    #region 플레이어상태

    private void PlayerStatursInitalize() // MainCanversInitalize()에서 호출 사용 다른곳에서 사용 x
    {

        for (int i = 0; i < panels[(int)e_Panel.상태창].transform.childCount; i++)
        {

            string compo_name = panels[(int)e_Panel.상태창].transform.GetChild(i).name;

           
            if (compo_name == "AttackImg")
            {
                GameObject img = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;

                Tmp_Attack = img.transform.GetComponentInChildren<TextMeshProUGUI>();
            }
            else if (compo_name == "DefenceImg")
            {
                GameObject img = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;

                Tmp_Defenc = img.transform.GetComponentInChildren<TextMeshProUGUI>();
            }
            else if (compo_name == "Speed_Img")
            {
                GameObject img = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;

                Tmp_Speed = img.transform.GetComponentInChildren<TextMeshProUGUI>();
            }

        }
    }

    public int IndexReder(int Itemtype)
    {
        
        if(Itemtype != 1)
        {
            return 0;
        }
        return 1;
    }

    #endregion


    public void Use()
        { 
        if (using_Target == null)
        {
            Debug.Log("여기?");
            return;
        }

        ItemObject item = using_Target.GetComponent<ItemObject>();

        

        int type = (int)DataBase.getInstance().GetItem[IndexReder(item.type)][item.id].Type;

        UserEquipSlot myslot = m_EquipSlot[type].GetComponent<UserEquipSlot>();
        //########### 이전 아이템 Relese #############
        if (myslot.ObjectBuffer != null)
        {
            UserData.getInstance().slotList[type] = null;
            myslot.ObjectBuffer.SetActive(true);
            myslot.ObjectBuffer = null;
        }
        //########### 이전 아이템 Relese #############

        //########### 대상 이이템 Hide 및 주소 참조#############
        myslot.ObjectBuffer = using_Target;
        myslot.ObjectBuffer.SetActive(false);
        //########### 대상 이이템 Hide 및 주소 참조#############

        //########### 장착아이템 올리기#############
        myslot.id = item.id;
        myslot.type = item.type;
        myslot.Rank = item.rank;
        myslot.number = item.numbering;
        myslot.Scericse = item.constellation;
        myslot.UserStateUpdate(item.type); //아이템 이아이콘을 지정한다 스테이트를 호출한다
        myslot.ShowSetAction();
        //########### 장착아이템 올리기#############

        //########### 리스트 추가 및 저장############
        UserData.getInstance().slotList[item.type].id = myslot.id;
        UserData.getInstance().slotList[item.type].number_id = item.numbering;
        UserData.getInstance().slotList[item.type].itemtype = myslot.type;
        UserData.getInstance().slotList[item.type].rank = myslot.Rank;
        UserData.getInstance().slotList[item.type].constellation = myslot.Scericse;
        UserData.getInstance().AllWirteUserData();
        //########### 리스트 추가 및 저장############

        using_Target = null;
    }
    public void EquipItemPanelInitalize()
    {
      
        if (GameObject.Find("HelmetEquipSlot") == null)
        {
            return;
        }
        else 
        {

            m_EquipSlot[(int)e_Itemtype.헬멧] = GameObject.Find("HelmetEquipSlot");
            m_EquipSlot[(int)e_Itemtype.무기] = GameObject.Find("WeaponEquipSlot");
            m_EquipSlot[(int)e_Itemtype.방어구] = GameObject.Find("ArmorEquipSlot");
            m_EquipSlot[(int)e_Itemtype.장신구] = GameObject.Find("AccessoryEquipSlot");
        }
    }
    public GameObject using_Target;
    public void RemoveMyData()
    {
        for (int i = 0; i < UserData.getInstance().InvenItemList.Count; i++)
        {
            Debug.Log("현제 인밴토리 id = " + UserData.getInstance().InvenItemList[i] + "지웁니다");

           // UserData.getInstance().InvenItemList.RemoveAt(i);
        }

    }
    public void ShowUserState(int atk, int def, float speed)
    {

        Tmp_Attack.GetComponent<TextMeshProUGUI>().text =
        atk.ToString();
        Tmp_Defenc.GetComponent<TextMeshProUGUI>().text =
        def.ToString();
        Tmp_Speed.GetComponent<TextMeshProUGUI>().text =
        speed.ToString();
    }
    public bool Findfile(string str)
    {
        bool result;
       

        FileInfo fi = new FileInfo(str);

        if (fi.Exists)
        {


            result = true;
            return result;
        }

        else
        {
            result = false;
            Debug.LogWarning("파일이 존재하지않아 새로 생성됩니다");
            UserData.getInstance().AllWirteUserData(str);

            return result;
        }


    }
    public IEnumerator LoadScene(int SceneNumber)
    {
        yield return null;

        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(SceneNumber);
        while (!asyncOper.isDone)
        {


            if (asyncOper.progress >= 0.1f)
            {
                // 여기 확인
                //  GameManager.instance.GetComponent<AudioSource>().Stop();
            }
            if (asyncOper.progress >= 0.3f)
            {

            }
            if (asyncOper.progress >= 0.5f)
            {

            }
            if (asyncOper.progress >= 0.9f)
            {
                asyncOper.allowSceneActivation = true;

            }
            yield return null;
        }
    }

    public T LoadJsonFile<T>(string loadPath, string fileName)
{   
    FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
    byte[] data = new byte[fileStream.Length];
    fileStream.Read(data, 0, data.Length);
    fileStream.Close();
    string jsonData = System.Text.Encoding.UTF8.GetString(data);
    return JsonUtility.FromJson<T>(jsonData);
}

 

    public void GetUsingItems()
    {
        Debug.Log("반환 대상 알려드립니다");
        for (int i= 0; i < m_EquipSlot.Length; i++)
        {
          
            UserEquipSlot slot = m_EquipSlot[i].GetComponent<UserEquipSlot>();

            if (slot.id == -1)
                return;


            if (slot.type == 1) //무기
            {
                Debug.Log("무기 " + i + " = " + DataBase.getInstance().GetItem[slot.type][slot.id].name);
                Debug.Log("무기 사정거리" + i + " = " + DataBase.getInstance().dic_Weapon[slot.id].leanth);
                Debug.Log("이미지" + i + " = " + DataBase.getInstance().dic_Weapon[slot.id].buletImg);
            }
            else
            {
                Debug.Log("방어구 " + i + " = " + DataBase.getInstance().GetItem[slot.type][slot.id].name);
            }
        }
    }

    public string RanktoString(int number)
    {
        string Result = "";
        switch (number)
        {
            case 0:
                Result = "은은한 ";
                return Result;
            case 1:
                Result = "반짝이는 ";
                return Result;
            case 2:
                Result = "빛나는 ";
                return Result;
            case 3:
                Result = "찬란한 ";
                return Result;
            case 4:
                Result = "광휘의 ";
                return Result;
            default:
                return Result;
        }
    }


    public string ConstellationtoString(int number)
    {
        string Result = "";
        switch (number)
        {
            case 0:
                Result = "물병자리 ";
                return Result;
            case 1:
                Result = "물고기자리 ";
                return Result;
            case 2:
                Result = "양자리 ";
                return Result;
            case 3:
                Result = "황소자리 ";
                return Result;
            case 4:
                Result = "쌍둥이자리";
                return Result;
            case 5:
                Result = "게자리 ";
                return Result;
            case 6:
                Result = "사자자리 ";
                return Result;
            case 7:
                Result = "처녀자리 ";
                return Result;
            case 8:
                Result = "천칭자리 ";
                return Result;
            case 9:
                Result = "전갈자리 ";
                return Result;
            case 10:
                Result = "사수자리 ";
                return Result;
            case 11:
                Result = "염소자리 ";
                return Result;
            default:
                return Result;
        }
    }

}


