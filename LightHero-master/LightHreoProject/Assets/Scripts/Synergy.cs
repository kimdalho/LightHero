using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy
{
    public int id;
    public Sprite img;
    public int BuffAttack;
    public int BuffDefenc;
    public float BuffSpeed;

    public Synergy(int id, Sprite img, int atk, int def, float spd)
    {
        this.id = id;
        this.img = img;
        this.BuffAttack = atk;
        this.BuffDefenc = def;
        this.BuffSpeed = spd;
    }



}
