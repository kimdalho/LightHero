using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //커넥션 = 0, // DisconnectPanel
    //상점 = 1, // ShopPanel
    //인벤창 = 2, // InvenPanel
    //로비 = 3, // LobbyPanel
    //상태창 = 4, // PlayerStatursPanel

    public Button[] Exit;
    public Button ConnecBtn;
    public Button InvetroyBtn;
    public Button ShopBtn;
    public Button DeongenBtn;
    public Button ItemUseBtn;
    public Button ItemBuyBtn;
    public Button LobbyBtn;


    public void Start()
    {
        ConnecBtn.onClick.AddListener(ConnectSetUp);
        InvetroyBtn.onClick.AddListener(Inven_ButtonSetup);
        ShopBtn.onClick.AddListener(Shop_ButtonSetup);
        LobbyBtn.onClick.AddListener(Lobby_ButtonSetup);
        DeongenBtn.onClick.AddListener(LoadDungeon);
        ItemBuyBtn.onClick.AddListener(BuySetUp);
        ItemUseBtn.onClick.AddListener(UseSetUp);

        for (int i = 0; i < Exit.Length; i++)
        {
            Exit[i].onClick.AddListener(Exitinit);
        }

    }

    public virtual void Shop_ButtonSetup()
    {
        GameManager.getInstance().SwichpanelsView(GameManager.e_Panel.상점);

    }
    public void Inven_ButtonSetup()
    {
        GameManager.getInstance().SwichpanelsView(GameManager.e_Panel.인벤창);

    }
    public void LoadDungeon()
    {
        StartCoroutine(GameManager.getInstance().LoadScene(1));

    }
    public void Lobby_ButtonSetup()
    {
        GameManager.getInstance().SwichpanelsView(GameManager.e_Panel.로비);

    }
    public void ConnectSetUp()
    {
        GameManager.getInstance().Connect();

    }
    public void Exitinit()
    {
            GameManager.getInstance().SwichpanelsView(GameManager.e_Panel.커넥션);
    }
    public void UseSetUp()
    {
        GameManager.getInstance().Use();
    }
    public void BuySetUp()
    {
        GameManager.getInstance().Buy();
    }
}
