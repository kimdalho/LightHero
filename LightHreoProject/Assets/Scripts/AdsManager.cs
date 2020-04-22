using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements; //Ver.2 플러그인 이용안함

public class AdsManager : MonoBehaviour
{
    public const string placementid = "rewardedVideo";
    public const string GameId = "3525263";
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GameId);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowAds()
    {

        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show();
        }

    }


    public void ShowRewardedAd() // 핵심
    {
        if (Advertisement.IsReady(placementid))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("video", options);
        }
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            UserData.getInstance().AddMoney(500);
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("광고 스킵");
        }

        else if (result == ShowResult.Failed)
        {
            Debug.LogWarning("광고 실패 ?");
        }

    }
}
