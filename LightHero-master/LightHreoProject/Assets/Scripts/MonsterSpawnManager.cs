using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MonsterPrefabs; //나중에 복수로

    public int SpawnMinCont;
    public int SpawnMaxCount; 

    void Start()
    {
        int rnd = Random.Range(SpawnMinCont, SpawnMaxCount);

        for (int i = 0; i < rnd; i++)
        {
            GameManager.getInstance().Filed_MonsterCount++;
            GameObject go = Instantiate(MonsterPrefabs);
            go.transform.position = transform.position;
            go.GetComponent<SpriteRenderer>().sortingOrder = GameManager.getInstance().Filed_MonsterCount;
        }
    }

}
