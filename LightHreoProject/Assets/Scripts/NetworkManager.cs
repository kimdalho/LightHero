using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
 
  
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
       

        Screen.SetResolution(960, 540, false);

    }

    private void Start()
    {
      

    }



}
