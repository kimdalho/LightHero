using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DungeonManager : MonoBehaviour
{
    enum e_UI
    {
        컨트롤러 = 0,
        공격버튼 = 1,
    }
    public static DungeonManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(instance);
        }

    }

    private bool onFinedplayer;

    public PlayerController player;

    public GameObject Panel;
    public GameObject Tmp_MonstCount;

    void Start()
    {
         
        onFinedplayer = false;
        GameSceneInitalize();
        SpawnPlayer();
    }

    private void Update()
    {
        FindPlayer(onFinedplayer);
    }

    private void FindPlayer(bool flage)
    {
        if (onFinedplayer == false)
        {
            if(GameObject.Find("Player") == null)
            {
                return;
            }
            else
            {
                player = GameObject.Find("Player").GetComponent<PlayerController>();
                onFinedplayer = true;
            }        
        }

    }


    GameObject Btn_Open;
    public void GameSceneInitalize()
    {
        if (GameObject.Find("PlayerUI") == null)
        {
            Debug.LogWarning("PlayerUI 객체를 찾지못하여 반환합니다");
            return;
        }

        GameObject mainCvs = GameObject.Find("PlayerUI");

        for (int i = 0; i < mainCvs.transform.childCount; i++)
        {
            string compo_name = mainCvs.transform.GetChild(i).name;

            switch (compo_name)
            {
                case "Btn_Attack":
                    GameManager.getInstance().panels[(int)e_UI.공격버튼] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "Img_JoyStick":
                    GameManager.getInstance().panels[(int)e_UI.컨트롤러] = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "Nameless":
                    Panel = mainCvs.transform.GetChild(i).gameObject;
                    break;
                case "Btn_Open":
                    Btn_Open = mainCvs.transform.GetChild(i).gameObject;
                    break;
                    
            }
        }

        GameObject grid =  GameObject.Find("Grid");

        for (int i = 0; i < grid.transform.childCount; i++)
        {
            string compo_name = grid.transform.GetChild(i).name;

            switch (compo_name)
            {
                case "Wall":
                    WallTiled = grid.transform.GetChild(i).gameObject;
                    Debug.Log("공격버튼 초기화 완료");
                    break;

            }
        }

        for (int i = 0; i < Panel.transform.childCount; i++)
        {
            string compo_name = Panel.transform.GetChild(i).name;

            Debug.Log(compo_name);

            switch (compo_name)
            {
                case "Tmp_MonsterCount":
                    Tmp_MonstCount = Panel.transform.GetChild(i).gameObject;
                    Debug.Log("공격버튼 초기화 완료");
                    break;
              
            }
        }
        //여기
        Tmp_MonstCount.GetComponent<TextMeshProUGUI>().text += GameManager.getInstance().Filed_MonsterCount.ToString();


    }


    public void SetMonsterCountText(int val)
    {
        Tmp_MonstCount.GetComponent<TextMeshProUGUI>().text = val.ToString();
    }



    public void OnAttack()
    {
        if (player == null)
        {
            return;
        }
        else
        {
            player.b_Attack = true;
            player.GetComponent<Animator>().SetBool("b_Attack", player.b_Attack);
        }
    }

    public void WallBreack()
    {
        b_BrackWall = false;
        WallTiled.SetActive(b_BrackWall);
        Btn_Open.SetActive(b_BrackWall);

    }
    bool b_BrackWall;
    public GameObject WallTiled;

  
    void ViewWall(bool _b_BrackWall)
    {
        WallTiled.SetActive(_b_BrackWall);
    }

    public Text RoomInfoText;
    public GameObject playerPrefb;
    public void SpawnPlayer()
    {
        Vector2 playerSpawnPos;
        playerSpawnPos.x = Random.Range(-1.67f, -1.20f); //  
        playerSpawnPos.y = Random.Range(1.34f, 0.96f);   // 
        //GameObject go = Instantiate(playerPrefb, playerSpawnPos, Quaternion.identity);
        GameObject go = Instantiate(Resources.Load("Player", typeof(GameObject))) as GameObject;
        go.transform.position = playerSpawnPos;
        go.name = "Player";
        CameraMovement.instance.SetViewTarget(go.transform);
    }

    public void LoadLobby()
    {
        GameManager.getInstance().Filed_MonsterCount = 0;
        StartCoroutine(GameManager.getInstance().LoadScene(1));
    }

}
