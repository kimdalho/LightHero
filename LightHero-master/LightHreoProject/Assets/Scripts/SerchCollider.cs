using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerchCollider : MonoBehaviour
{
    private PolygonCollider2D p_Cld;
    private BoxCollider2D par_cld;

    private void Awake()
    {
        par_cld = GetComponentInParent<BoxCollider2D>();
    }

    private void Start()
    {
        p_Cld = GetComponent<PolygonCollider2D>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Object")
        {
          //  par_cld.isTrigger = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
          //  par_cld.isTrigger = true;
        }
    }


}
