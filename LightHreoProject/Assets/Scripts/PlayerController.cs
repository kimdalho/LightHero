using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    enum e_MoveState
    {
        Forward = 0,
        Back = 1,
        Left = 2,
        Right = 3,
    }
    PolygonCollider2D SerchWall2d;
    struct str_Pos
    {
      public  float PosX;
      public  float PosY;
    }

    public float rayDir;

    Animator animator;
    Rigidbody2D rb2d;
    str_Pos MovePos;
 

    GameObject childe_Weapon;
    Rigidbody2D childe_WeaponRb2d;
    BoxCollider2D childe_Weaponcollider;

    float movePower;
    public bool b_Attack;


    // "SerchWall"

    public void Start()
    {
        SerchWall2d = GetComponentInChildren<PolygonCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
   
        movePower = 1;


        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            string compo_name;
            compo_name = gameObject.transform.GetChild(i).name;
            if (compo_name == "Weapon")
            {
                childe_Weapon = gameObject.transform.GetChild(i).gameObject;
            }

        }


        childe_WeaponRb2d = childe_Weapon.GetComponent<Rigidbody2D>();
        childe_Weaponcollider = childe_Weapon.GetComponent<BoxCollider2D>();

        childe_Weapon.SetActive(false);

    }


    private void MoveController(bool Mod)
    {
        if (Mod == true)
        {
            MovePos.PosX = Input.GetAxisRaw("Horizontal") * movePower;
            MovePos.PosY = Input.GetAxisRaw("Vertical") * movePower;
        }
        else if (Mod == false)
        {
            controller = GameManager.getInstance().panels[0].GetComponent<VirtualJoystick>();

            MovePos.PosX = controller.inputVector.x;
            MovePos.PosY = controller.inputVector.y;
        }

    }


    VirtualJoystick controller;
    private void FixedUpdate()
    {
        
      

            MoveController(GameManager.getInstance().MoveMod);
            if (rb2d.velocity.magnitude > 0)
            {
                animator.SetBool("Mb_Forwrd", true);
            }
            else
            {
                animator.SetBool("Mb_Forwrd", false);
            }
        
            rb2d.velocity = new Vector2(MovePos.PosX, MovePos.PosY);
        OtherPlayersMoveAnimation(rb2d.velocity.x,rb2d.velocity.y);
    }

 
    void OtherPlayersMoveAnimation(float _X, float _Y)
    {

        if (rb2d == null)
            return;
        rb2d.velocity = new Vector2(_X, _Y);





        if ((_Y == 0) && (_X == 0))
            return;

        animator.SetFloat("PosY", _Y);
        animator.SetFloat("PosX", _X);
    }


 

    void Ae_EndAttack()
    {
        b_Attack = false;
        animator.SetBool("b_Attack", b_Attack);
    }

 

    void Ae_OnAttackedCollisionEnd()
    {
        childe_Weapon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("충돌 이벤트 대상 이름" + collision.name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    enum e_direction
    {
        Down = 0,
        Up = 1,
        Left = 2,
        Right = 3,
    }



    #region 애니메이션
    //Left
    //Offset (-0.07 , 0f) Size (0.07,0.15)

    //Right
    //Offset (0.07 , 0f) Size (0.07,0.15)

    //Forward 
    //Offset (-0.004f , -0.1f) Size (0.15,0.07)

    //Back
    //Offset (-0.004f , 0.09f) Size (0.15,0.07)

    void Ae_OnAttackedCollisonStart(e_MoveState m_MoveState)
    {
        childe_Weapon.SetActive(true);
        //        Debug.Log(m_MoveState);
        switch (m_MoveState)
        {
            case e_MoveState.Forward:
                {
                    //Forward 
                    //Offset (-0.004f , -0.1f) Size (0.15,0.07)
                    childe_Weapon.GetComponent<BoxCollider2D>().offset = new Vector2(-0.07f, 0f);
                    childe_Weapon.GetComponent<BoxCollider2D>().size = new Vector2(0.07f, 0.15f);

                   
                    break;
                }
            case e_MoveState.Back:
                {
                    //Back
                    //Offset (-0.004f , 0.09f) Size (0.15,0.07)
                    childe_Weapon.GetComponent<BoxCollider2D>().offset = new Vector2(-0.004f, 0.09f);
                    childe_Weapon.GetComponent<BoxCollider2D>().size = new Vector2(0.15f, 0.07f);
                    break;
                }
            case e_MoveState.Left:
                {
                    //Left
                    //Offset (-0.07 , 0f) Size (0.07,0.15)
                    childe_Weapon.GetComponent<BoxCollider2D>().offset = new Vector2(-0.004f, -0.1f);
                    childe_Weapon.GetComponent<BoxCollider2D>().size = new Vector2(0.15f, 0.07f);
                    break;
                }
            case e_MoveState.Right:
                {
                    //Right
                    //Offset (0.07 , 0f) Size (0.07,0.15)
                    childe_Weapon.GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, 0f);
                    childe_Weapon.GetComponent<BoxCollider2D>().size = new Vector2(0.07f, 0.15f);
                    break;
                }
        }

    }
    #endregion
}
