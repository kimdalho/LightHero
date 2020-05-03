using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData 
{
    public  int id;
    public  int number_id;
    public  int itemtype;
    public  int rank;
    public  int constellation;


    public SaveData()
    {
        this.id = -1;
        this.number_id = -1;
        this.itemtype = -1;
        this.rank  =  -1;
        this.constellation = -1;
    }

    public SaveData(int id,int number_id, int itemtype, int rank, int constellation)
    {
        this.id = id;
        this.number_id = number_id;
        this.itemtype = itemtype;
        this.rank = rank;
        this.constellation = constellation;
    }

    public void printData()
    {
        Debug.Log("SaveData id" + this.id);
        Debug.Log("SaveData number" + this.number_id);
        Debug.Log("SaveData itemtype" + this.itemtype);
        Debug.Log("SaveData rank" + this.rank);
        Debug.Log("SaveData constellation" + this.constellation);
    }

}
