using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float life;
    public int atk;
    public int def;
    public int speed;



    enum e_ZombieStaturs
    {
        Idle,
        Follow,
        Deth,
    }

    private bool arrive; //도착여부 True면 도착 false면 도착하지않음
    private bool isDie;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 destination;
    public float movePower;
    private bool onIdleMove; // true면 움직여도 됨 false면 움직이면안됨
    public float deltime;
    public float LimitedTime = 2f;
    GameObject target;
    e_ZombieStaturs staturs;
    class Pos
    {
        public float X;
        public float Y;

        public Pos()
        {
            X = 0;
            Y = 0;
        }

        public Vector2 GetPos()
        {
            Vector2 Result;
            Result.x = this.X;
            Result.y = this.Y;

            return Result;
        }

        public void SetPos(float _X, float _Y)
        {

            this.X = _X;
            this.Y = _Y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
   
        animator = GetComponent<Animator>();
        onIdleMove = true;
        staturs = e_ZombieStaturs.Idle;
        isDie = false;
        rb2d = GetComponent<Rigidbody2D>();
        destination = Vector2.zero;
    }

    private void SerchPlayer()
    {
        
    }

    void Update()
    {
        switch (staturs)
        {
            case e_ZombieStaturs.Idle:
                StartCoroutine(Idling());
                break;
            case e_ZombieStaturs.Follow:
                Folloing();
                break;
            case e_ZombieStaturs.Deth:
                break;
        }
    }


    IEnumerator Idling()
    {
     
        if (onIdleMove == true)
        {
            deltime = 0;
            onIdleMove = false;
            Pos buffer = new Pos();
            buffer.X = Random.Range(-5f, 5f);
            buffer.Y = Random.Range(-5f, 5f);
            destination = buffer.GetPos();
            arrive = false;
            


            while (!arrive)
            {
                deltime += Time.deltaTime;

                rb2d.velocity = (destination.normalized * movePower);
                Pos thisPos = new Pos();
                thisPos.SetPos(transform.position.x, transform.position.y);
                MoveAnimation();
              //
                yield return new WaitForSeconds(Time.deltaTime);
                
                if (deltime >= LimitedTime)
                {
                    rb2d.velocity = Vector2.zero;
                    arrive = true;
                }
            }


            yield return new WaitForSeconds(1f);
            onIdleMove = true;

        }
        else
        {
            while (staturs != e_ZombieStaturs.Idle)
            {
                yield return null;
            }
        }
    }
    
    private void MoveAnimation()
    {
        animator.SetFloat("PosX", rb2d.velocity.x);
        animator.SetFloat("PosY", rb2d.velocity.y);
    }

    private void Folloing()
    {
      

        Vector2 distance =  target.transform.position - transform.position;

        Vector2 normalVec = distance.normalized;

        rb2d.velocity = normalVec * movePower;
        MoveAnimation();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "OtherPlayer")
        {
            target = collision.gameObject;
            staturs = e_ZombieStaturs.Follow;
        }
    }


    public void Damage()
    {

        if(this.life < 0)
        {
            Destroy(gameObject);
            GameManager.instance.Filed_MonsterCount--;

            if(GameManager.instance.Filed_MonsterCount <= 0)
            {
                NetworkManager.instance.DengeonClear();
            }

            DungeonManager.instance.SetMonsterCountText(GameManager.instance.Filed_MonsterCount);
        }
        else
        {
            this.life -= GameManager.instance.m_atack;

            Debug.Log("life");
        }


    }


}
