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
    public Button InvetroyBtn;
    public Button ShopBtn;
  
    public Button LobbyBtn;
    public Button FuseBtn;

    public Color[] lv_c = new Color[4];

    public Button[] LevelControllerBtns;
    [Header("Deongens")]

    public int[] level = new int[4];
    public Button DeongensBtn;
    public Button HighDeongenBtn;

    public void Start()
    {
        level[0] = 0;
        level[1] = 0;


        InvetroyBtn.onClick.AddListener(Inven_ButtonSetup);
        ShopBtn.onClick.AddListener(Shop_ButtonSetup);
        LobbyBtn.onClick.AddListener(Lobby_ButtonSetup);
        DeongensBtn.onClick.AddListener(LoadDungeon);
        HighDeongenBtn.onClick.AddListener(LoadDefencDungeon);
       

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
        //이렇게 쓰는거야
       GameManager.getInstance().GetUsingItems();
        Debug.Log("일반 던전 래밸" + level[0]); // level 0 이 일반던전 리설트

    }
    public void LoadDefencDungeon()
    {
        GameManager.getInstance().GetUsingItems();
        Debug.Log("디펜스 던전 래밸" + level[1]); // level 1이 디펜스던전 리선트
    }

    public void Lobby_ButtonSetup()
    {
        GameManager.getInstance().SwichpanelsView(GameManager.e_Panel.로비);

    }

    public void Exitinit()
    {
            GameManager.getInstance().SwichpanelsView(GameManager.e_Panel.커넥션);
    }
    public void UseSetUp()
    {
     //   GameManager.getInstance().Use();
    }
    public void BuySetUp()
    {
    //    GameBord.getInstance.;
    }

    public void LevelDown(int number)
    {
        switch(number)
        {
            case 0:
                switch (level[number])
                {
                    case 0:
                        break;
                    case 1:
                        level[number] -= 1;
                        DeongensBtn.gameObject.GetComponentInChildren<Text>()
                        .text = "쉬움";
                        DeongensBtn.gameObject.GetComponentInChildren<Text>().color
                            = lv_c[0];
                        break;
                    case 2:
                        level[number] -= 1;
                        DeongensBtn.gameObject.GetComponentInChildren<Text>()
                        .text = "보통";
                        DeongensBtn.gameObject.GetComponentInChildren<Text>().color
                        = lv_c[1];
                        break;
                }
                break;
            case 1:
                switch (level[number])
                {
                    case 0:
                        break;
                    case 1:
                        level[number] -= 1;
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>()
                        .text = "쉬움";
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>().color
                        = lv_c[0];
                        break;
                    case 2:
                        level[number] -= 1;
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>()
                        .text = "보통";
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>().color
                      = lv_c[1];
                        break;
                }
                break;

        }
    }

    public void LevelUp(int number)
    {
        switch (number)
        {
            case 0:
                switch (level[number])
                {
                    case 0:
                        level[number] += 1;
                        DeongensBtn.gameObject.GetComponentInChildren<Text>()
                       .text = "보통";
                        DeongensBtn.gameObject.GetComponentInChildren<Text>().color = lv_c[1];
                        break;
                    case 1:
                        level[number] += 1;
                        DeongensBtn.gameObject.GetComponentInChildren<Text>()
                       .text = "어려움";
                        DeongensBtn.gameObject.GetComponentInChildren<Text>().color = lv_c[2];
                        break;
                    case 2:

                        break;
                }
                break;
            case 1:
                switch (level[number])
                {
                    case 0:
                        level[number] += 1;
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>()
                       .text = "보통";
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>().color = lv_c[1];
                        break;
                    case 1:
                        level[number] += 1;
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>()
                       .text = "어려움";
                        HighDeongenBtn.gameObject.GetComponentInChildren<Text>().color = lv_c[2];
                        break;
                    case 2:

                        break;
                }
                break;
        }
      
    }

}
