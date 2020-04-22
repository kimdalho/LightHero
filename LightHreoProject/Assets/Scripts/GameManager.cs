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
        //GameManager.instance
        //GameManager.getInstance()
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
    public GameObject[] panels = new GameObject[5];
    public InputField nickNameInput;
    public enum e_Panel
    {
        커넥션 = 0, // DisconnectPanel
        상점 = 1, // ShopPanel
        인벤창 = 2, // InvenPanel
        로비 = 3, // LobbyPanel
        상태창 = 4, // PlayerStatursPanel
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
    public GameObject Tmp_money;
    public GameObject Tmp_Attack;
    public GameObject Tmp_Defenc;
    public GameObject Tmp_Speed;
    [Header("InventoryPanel")]
    public GameObject[] m_EquipSlot = new GameObject[4];
    [Header("ItemShopPanel")]
    public Image ItemdescriptionPanel;
    public Image Story_Panel;
    public GameObject ShopContent;
    public GameObject ItemBuyBtn;
    public GameObject ItemUseBtn;
    public Text Sp_ItemNameText;
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
        Tmp_money.GetComponent<TextMeshProUGUI>().text = "Money" + UserData.getInstance().m_money;
        return UserData.getInstance().m_money;
    }
    public void SetAttack(int value)
    {
        UserData.getInstance().m_atack = value;
        Tmp_Attack.GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_atack.ToString();

    }
    public int SetDefenc(int value)
    {
        UserData.getInstance().m_defenc = value;
        Tmp_Defenc.GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_defenc.ToString();
        return UserData.getInstance().m_defenc;
    }
    public float SetSpeed(float value)
    {
        UserData.getInstance().m_speed = value;

        Tmp_Speed.GetComponent<TextMeshProUGUI>().text = UserData.getInstance().m_speed.ToString();
        return UserData.getInstance().m_speed;
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
            DataBase.getInstance().ItemListCall();
            for (int i = 0; i < DataBase.getInstance().itemList.Count; i++)
            {
                GameManager.getInstance().ItemCSVRender(i);
            }
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
                case "DisconnectPanel":
                    panels[(int)e_Panel.커넥션] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "ItemdescriptionPanel":
                    ItemdescriptionPanel = mainCvs.transform.GetChild(i).GetComponent<Image>();
                    break;
                case "ShopPanel":
                    panels[(int)e_Panel.상점] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "InvenPanel":
                    panels[(int)e_Panel.인벤창] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "LobbyPanel":
                    panels[(int)e_Panel.로비] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "PlayerStatursPanel":
                    panels[(int)e_Panel.상태창] = mainCvs.transform.GetChild(i).gameObject;
                    break;
            }
        }

        DisconnectPanelInitalize();

        ItemShopInitalize();

        LobbyPanelInitalize();

        PlayerStatursInitalize();

        InventoryPanelInitalize();

        EquipItemPanelInitalize();

        ShopPanelInit();

        // SwichpanelsView(e_Panel.커넥션);
    }
    public void ItemShopInitalize()
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

                case "ItemUseBtn":
                    ItemUseBtn = ItemdescriptionPanel.transform.GetChild(i).gameObject;
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

                case "Sp_ItemImg":
                    Sp_ItemImg = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Image>();
                    break;
                case "Sp_ItemStoryText":
                    Sp_ItemStoryText = Story_Panel.transform.GetChild(i).gameObject.GetComponent<Text>();
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
                    panels[(int)e_Panel.커넥션].SetActive(true);
                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(false);

                    ItemdescriptionPanel.gameObject.SetActive(false);
                    break;
                }
            case e_Panel.상점:
                {
                    panels[(int)e_Panel.커넥션].SetActive(false);
                    panels[(int)e_Panel.상점].SetActive(true);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(false);

                    ItemdescriptionPanel.gameObject.SetActive(true);
                    ItemUseBtn.SetActive(false);
                    ItemBuyBtn.SetActive(true);
                    break;
                }
            case e_Panel.인벤창:
                {
                    panels[(int)e_Panel.커넥션].SetActive(false);
                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(true);
                    panels[(int)e_Panel.로비].SetActive(false);

                    ItemdescriptionPanel.gameObject.SetActive(true);
                    ItemUseBtn.SetActive(true);
                    ItemBuyBtn.SetActive(false);

                    break;
                }
            case e_Panel.로비:
                {
                    panels[(int)e_Panel.커넥션].SetActive(false);
                    panels[(int)e_Panel.상점].SetActive(false);
                    panels[(int)e_Panel.인벤창].SetActive(false);
                    panels[(int)e_Panel.로비].SetActive(true);

                    ItemdescriptionPanel.gameObject.SetActive(false);

                    break;
                }

            default:
                {
                    Debug.LogWarning("SwichpanelsView에 지정되어있지않은 상태가 출력되었습니다");
                    break;
                }


        }
    }
    public void Connect()
    {
        LoginPanel.SetActive(false);
        ButtonPanel.SetActive(true);
        LoadData();
    }
    #endregion
    #region 디스커넥션

    public void DisconnectPanelInitalize()
    {
        for (int i = 0; i < panels[(int)e_Panel.커넥션].transform.childCount; i++)
        {
            string compo_name = panels[(int)e_Panel.커넥션].transform.GetChild(i).name;

            switch (compo_name)
            {
                case "LoginPanel":
                    LoginPanel = panels[(int)e_Panel.커넥션].transform.GetChild(i).gameObject;
                    LoginPanel.SetActive(true);
                    break;

                case "ButtonPanel":
                    ButtonPanel = panels[(int)e_Panel.커넥션].transform.GetChild(i).gameObject;
                    ButtonPanel.SetActive(false);
                    break;
            }
        }



        for (int i = 0; i < LoginPanel.transform.childCount; i++)
        {
            string compo_name = LoginPanel.transform.GetChild(i).name;

            switch (compo_name)
            {
                case "NickNameInput":
                    nickNameInput = LoginPanel.transform.GetChild(i).GetComponent<InputField>();

                    break;

                case "ConnecBtn":
                    ConnectBtn = LoginPanel.transform.GetChild(i).gameObject;

                    break;

                case "NickNameLabel":
                    NickNameLabel = LoginPanel.transform.GetChild(i).gameObject;

                    break;
            }
        }



    }


    #endregion
    #region 상점

    public void ShopPanelInit()
    {
        ShopContent = GameObject.Find("ShopContent");
    }

    #endregion
    #region 인벤토리

    public GameObject InventoryContent;

    private void InventoryPanelInitalize()
    {

        InventoryContent = GameObject.Find("InventoryContent");

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

        RoomControllPanelSetUp(RoomControllPanel);
    }

    private void RoomControllPanelSetUp(GameObject targetObject)
    {
        for (int i = 0; i < targetObject.transform.childCount; i++)
        {
            string compo_name = targetObject.transform.GetChild(i).name;

            switch (compo_name)
            {
                case "RoomInput":
                    roomInput = targetObject.transform.GetChild(i).gameObject.GetComponent<TMP_InputField>();
                    break;

            }

        }
    }

    #endregion
    #region 플레이어상태

    private void PlayerStatursInitalize() // MainCanversInitalize()에서 호출 사용 다른곳에서 사용 x
    {
        if (panels[(int)e_Panel.상태창] == null)
        {
            Debug.LogWarning("플레이어 상태창이 초기화가 이루어지지 못했다");
            return;
        }

        //여기를 모르겠다는건가

        for (int i = 0; i < panels[(int)e_Panel.상태창].transform.childCount; i++)
        {

            string compo_name = panels[(int)e_Panel.상태창].transform.GetChild(i).name;

            if (compo_name == "Text_Gold")
            {
                Tmp_money = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;
            }
            else if (compo_name == "Text_Attack")
            {
                Tmp_Attack = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;
            }
            else if (compo_name == "Text_Def")
            {
                Tmp_Defenc = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;
            }
            else if (compo_name == "Text_Speed")
            {
                Tmp_Speed = panels[(int)e_Panel.상태창].transform.GetChild(i).gameObject;
            }

        }
    }

    #endregion
    public void LoadBuylist()
    {
        if (using_Target == null)
        {
            Debug.Log("대상이 존재하지않는다");
            return;
        }
        ItemObject item = using_Target.GetComponent<ItemObject>();
        //#################대상 아이템 좌표 변경 #######################
        using_Target.gameObject.transform.SetParent(InventoryContent.transform);
        Debug.Log("좌표를변경한다" + using_Target);
        //#################대상 아이템 좌표 변경 #######################

        //#################대상 UserData List추가 #######################
        UserData.getInstance().BuyItemList.Add(item.id);
        UserData.getInstance().AllWirteUserData();
        using_Target = null;
        //#################대상 UserData List추가 #######################

    }
    public void Buy()
    {
        if (using_Target == null) return;
        ItemObject item = using_Target.GetComponent<ItemObject>();
        //#################머니 비교 #######################
        //#################머니 비교 #######################
      
        //#################대상 아이템 좌표 변경 #######################
        using_Target.gameObject.transform.SetParent(InventoryContent.transform);
        //#################대상 아이템 좌표 변경 #######################

        //#################대상 UserData List추가 #######################
        UserData.getInstance().BuyItemList.Add(item.id);
        UserData.getInstance().AllWirteUserData();
        using_Target = null;
        //#################대상 UserData List추가 #######################

    }
    public void Use()
    {
        if (using_Target == null)
        {
            Debug.Log("여기?");
            return;
        }
        ItemObject item = using_Target.GetComponent<ItemObject>();
        int type = (int)DataBase.getInstance().dic_item[item.id].Type;
        UserEquipSlot myslot = m_EquipSlot[type].GetComponent<UserEquipSlot>();
        //########### 이전 아이템 Relese #############
        if (myslot.ObjectBuffer != null)
        {
            UserData.getInstance().userEqList[type] = -1;
            UserData.getInstance().BuyItemList.Add(myslot.id);
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
        myslot.UserStateUpdate();
        //########### 장착아이템 올리기#############

        //########### 리스트 추가 및 제거 ############
        
        UserData.getInstance().userEqList[type] = myslot.id;
        UserData.getInstance().BuyItemList.Remove(myslot.id);

        UserData.getInstance().AllWirteUserData();
        //########### 리스트 추가 및 제거 ############

        using_Target = null;
    }
    public void LoadUseList()
    {
        if (using_Target == null)
        {
            Debug.Log("여기?");
            return;
        }
        ItemObject item = using_Target.GetComponent<ItemObject>();
        int type = (int)DataBase.getInstance().dic_item[item.id].Type;
        UserEquipSlot myslot = m_EquipSlot[type].GetComponent<UserEquipSlot>();
        //########### 이전 아이템 Relese #############
        if (myslot.ObjectBuffer != null)
        {
            UserData.getInstance().userEqList[type] = -1;
            UserData.getInstance().BuyItemList.Add(myslot.id);
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
        myslot.UserStateUpdate();
        //########### 장착아이템 올리기#############

        //########### 리스트 추가 및 제거 ############

        UserData.getInstance().userEqList[type] = myslot.id;
        UserData.getInstance().BuyItemList.Remove(myslot.id);

        UserData.getInstance().AllWirteUserData();
        //########### 리스트 추가 및 제거 ############

    }
    public void EquipItemPanelInitalize()
    {
        //여기 에러
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
    public void ItemCSVRender(int number)
    {
        string str = DataBase.getInstance().itemList[number];
        string[] result = str.Split(new char[] { ',' });

        int id = int.Parse(result[0]);
        int itemtype = int.Parse(result[1]);
        Sprite img = DataBase.getInstance().ScerchImg(result[2]);

        string name = result[3];
        string story = result[4];
        int price = int.Parse(result[5]);
        int atk = int.Parse(result[6]);
        int def = int.Parse(result[7]);
        float speed = float.Parse(result[8]);

        DataBase.getInstance()
       .dic_item.Add(number, new ItemData(id, itemtype, img, name, story, price, atk, def, speed));
    }
    public void RemoveMyData()
    {
        for (int i = 0; i < UserData.getInstance().BuyItemList.Count; i++)
        {
            Debug.Log("현제 인밴토리 id = " + UserData.getInstance().BuyItemList[i] + "지웁니다");

            UserData.getInstance().BuyItemList.RemoveAt(i);
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
    public void LoadData()
    {
        Debug.Log("데이터를 불러왔습니다");

        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("FOR Android");
            if (Findfile(Application.persistentDataPath + "/UserItemData"))
            {
                string Jsonstring = File.ReadAllText(Application.persistentDataPath + "/UserItemData");
                JsonData userdata = JsonMapper.ToObject(Jsonstring);
                FillingMyItem(userdata);
            }
        }
        else
        {
            Debug.Log("hellow Pc With Log");
            if (Findfile(Application.dataPath + "/UserItemData"))
            {
                string Jsonstring = File.ReadAllText(Application.dataPath + "/UserItemData");
                JsonData userdata = JsonMapper.ToObject(Jsonstring);
                FillingMyItem(userdata);
            }
        }

    }

    public void LoadMoney(JsonData userdata)
    {
        if (userdata[0] != null)
        {
            SetMoney(int.Parse(userdata[0].ToString()));
       
        }
    }

    public void LoadMyInventroy(JsonData userdata)
    {
       
        if (userdata[1] != null)
        {
            for (int i = 0; i < userdata[1].Count; i++)
            {
                Debug.Log("여기 " + GameManager.getInstance().ShopContent.transform.childCount);
                for (int j = 0; j < GameManager.getInstance().ShopContent.transform.childCount; j++)
                {
                  
                    //#########비교###################
                    if (int.Parse(userdata[1][i].ToString()) ==
                        GameManager.getInstance().ShopContent.transform.GetChild(j).GetComponent<ItemObject>().id)
                    {
                       
                        using_Target = GameManager.getInstance().ShopContent.transform.GetChild(j).gameObject;

                        LoadBuylist();
                    }

                    //#########비교###################

                }
            }

        }
        else
        {
            Debug.LogWarning("구매리스트가 존재하지않습니다");
        }
    }

    public void LoadUsingItems(JsonData userdata)
    {
        
        //#########장착한 아이템리스트를 샵에서 인밴으로 이동###################
        if (userdata[2] != null)
        {
            for (int i = 0; i < userdata[2].Count; i++)
            {
                for (int j = 0; j < ShopContent.transform.childCount; j++)
                {
                    //#########비교###################

                   // Debug.Log("비교 " + int.Parse(userdata[2][i].ToString()) + "비교 " + ShopContent.transform.GetChild(j).GetComponent<ItemObject>().id);
                    if (int.Parse(userdata[2][i].ToString()) ==
                    ShopContent.transform.GetChild(j).GetComponent<ItemObject>().id)
                    {

                        GameObject target = ShopContent.transform.GetChild(j).gameObject;  //Buy;
                        target.transform.SetParent(InventoryContent.transform);
                        UserData.getInstance().BuyItemList.Add(target.GetComponent<ItemObject>().id);
                        using_Target = target;

                        LoadUseList();
                    }
                    //#########비교###################
                }
            }
        }
        //#########장착한 아이템리스트를 샵에서 인밴으로 이동###################
    }

    public void FillingMyItem(JsonData userdata)
    {
      
        LoadMoney(userdata);
        Debug.Log("?");
        LoadMyInventroy(userdata);
        Debug.Log("next");
        LoadUsingItems(userdata);


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
}

