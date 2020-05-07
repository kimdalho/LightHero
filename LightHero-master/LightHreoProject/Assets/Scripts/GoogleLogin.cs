using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
public class GoogleLogin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DebugText = GameObject.Find("Text").GetComponent<Text>();
        //구글 api를 이용해서 다른 api를 연동할시
        //구글 로그인후 다른 sdk를 지원하게 해준다
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestIdToken()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

    }
    public Text DebugText;
    public void SignIn()
    {
      

        Social.localUser.Authenticate((result,erroerMessage)=>{

            if(result)
            {
                Debug.Log("Good");
       
            }
            else
            {
                Debug.Log("LogCat" + erroerMessage);
            }
        });
            
            
            
    }
    public void NextSceneCall()
    {

        StartCoroutine(GameManager.getInstance().LoadScene(1));



    }

}
