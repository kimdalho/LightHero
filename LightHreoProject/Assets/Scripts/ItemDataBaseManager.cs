using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class ItemDataBaseManager : MonoBehaviour
{

    public GameObject GameObject_prefab;

    Dictionary<string, Dictionary<int, GameObject>> DB_GameObjects = new Dictionary<string, Dictionary<int, GameObject>>();
    Dictionary<int, GameObject> dic_weapon = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> dic_amor = new Dictionary<int, GameObject>();

    public GameObject[] weapons =new GameObject[3];
    public GameObject[] amors = new GameObject[3];

    enum e_GameObjectType
    {
        무기 = 0,
        방어구 = 1,
    }


    private void Initalize()
    {
     
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = Instantiate(GameObject_prefab);
            weapons[i].GetComponent<Item>().ItemTypeInitalize((int)e_GameObjectType.무기);
            dic_weapon.Add(i, weapons[i]);
        }

        for (int i = 0; i < amors.Length; i++)
        {
            amors[i] = Instantiate(GameObject_prefab);
            amors[i].GetComponent<Item>().ItemTypeInitalize((int)e_GameObjectType.방어구);
            dic_amor.Add(i, amors[i]);
        }

        DB_GameObjects.Add("Weapon", dic_weapon);
        DB_GameObjects.Add("Amor", dic_amor);
    }


    private void Start()
    {
       // Initalize();
    }



}
