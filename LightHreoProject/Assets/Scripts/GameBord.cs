using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBord : MonoBehaviour
{
    public GameObject itemPrefab;

    private void Start()
    {
        GameManager.getInstance().GameSetting();
        DisplayItem();
    }

    public void DisplayItem()
    {
        for (int i = 0; i < DataBase.getInstance().itemList.Count; i++)
        {
            if (itemPrefab == null)
            {
                Debug.LogError("itemPrefab 비어있다");
                return;
            }
            if (GameManager.getInstance().ShopContent == null)
            {
                Debug.LogError("ShopContent 비어있다");
                return;
            }

            GameObject product = Instantiate(itemPrefab);
            product.name = "item";
            product.GetComponent<ItemObject>().id = i;
            product.GetComponent<ItemObject>().ItemComponetInit();
            product.transform.SetParent(GameManager.getInstance().ShopContent.transform);
            product.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
