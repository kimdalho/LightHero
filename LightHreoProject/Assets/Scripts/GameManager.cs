using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    //보유해야 함
    #region 변수선언    

    static public GameManager instance = null;
    [Header("CanversPanels")]
    private string gameVersion = "1";
    public GameObject ButtonPanel;
    public GameObject LoginPanel;
    public GameObject[] panels = new GameObject[5];
    public InputField nickNameInput;

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
    public int m_money;
    public int m_atack;
    public int m_defenc;
    public float m_speed;
    [Header("InventoryPanel")]
    public GameObject[] EquipSlot;
    [Header("ItemShopPanel")]
    public Image ItemdescriptionPanel;
    public Image Story_Panel;
    public GameObject ShopContent;
    public GameObject ItemBuyBtn;
    public GameObject ItemUseBtn;
    public Text Sp_ItemNameText;
    public Image Sp_ItemImg;
    public Text Sp_ItemStoryText;
    [Header("Member variable")]
    public GameObject Btn_WallController;
    public int Filed_MonsterCount;
    public bool MoveMod;
    public TouchScreenKeyboard keyboard { get; private set; }
    #endregion
    public int Getm_money()
    {
        return this.m_money;
    }
    public int Setm_money(int addm_money)
    {
        this.m_money = addm_money;
        return this.m_money;
    }
    public int Add_Money(int value)
    {
        this.m_money += value;
        Tmp_money.GetComponent<TextMeshProUGUI>().text = m_money.ToString();
        return this.m_money;
    }
    public void Add_Attack(int value)
    {
        this.m_atack += value;
        // comma(string num)
        Tmp_Attack.GetComponent<TextMeshProUGUI>().text = m_atack.ToString();

    }
    public int Add_Defenc(int value)
    {
        this.m_defenc += value;
        // comma(string num)
        Tmp_Defenc.GetComponent<TextMeshProUGUI>().text = m_defenc.ToString();
        return this.m_defenc;
    }
    public float Add_Speed(float value)
    {
        this.m_speed += value;
        // comma(string num)
        Tmp_Speed.GetComponent<TextMeshProUGUI>().text = m_speed.ToString();
        return this.m_speed;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(gameObject);
    }




    private void Start()
    {

        GameManager.instance.Add_Attack(30);
        GameManager.instance.Add_Defenc(10);
        GameManager.instance.Add_Speed(10);


    }
    private string comma(string num)
    {
        int len, point;
        string str;

        num = num + "";
        point = num.Length % 3;
        len = num.Length;

        str = num.Substring(0, point);
        while (point < len)
        {
            if (str != "") str += ",";
            str += num.Substring(point, point + 3);
            point += 3;
        }

        return str;

    }

    public void TestFuntion()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, true, true, true);

            keyboard.active = true;
        }
    }


    #region SceneCut
    public void CreateRoom()
    {
        StartCoroutine(LoadScene(1));
    }
    public IEnumerator LoadScene(int SceneNumber)
    {
        yield return null;

        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(SceneNumber);
        while (!asyncOper.isDone)
        {


            if (asyncOper.progress >= 0.1f)
            {
                GameManager.instance.GetComponent<AudioSource>().Stop();
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
    public void DengeonClear()
    {
        StartCoroutine(LoadScene(0));
    }

    #endregion

}
