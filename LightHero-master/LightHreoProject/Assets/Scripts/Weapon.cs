using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(collision.tag == "Monster")
        {
            collision.GetComponent<Zombie>().Damage();
        }

    }




}
