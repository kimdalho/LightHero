using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    public Text ShowErro;
    public Text StatusText;
    public InputField roomInput, IdNameInput;

    public bool OnGameStart;
    bool Result;
    public static NetworkManager instance = null;


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
        Result = false;
        OnGameStart = false;
        Screen.SetResolution(960, 540, false);

    }




   
    // Update is called once per frame
    void Update()
    {
        if (StatusText == null)
            return;
      
    }
    
    public void DengeonClear()
    {

    }


    /******************
     * 문제 
     * 1.로비는 무작이의 로비를 선택한다
     * 2.host는 문제가 없이 잘나오지만 게스트는 호스트의 모습이 나오지않는다
     * 
     * 
     ******************/
}
