using UnityEngine;
using System.Collections;

public class player1Controler : MonoBehaviour
{
    KnockBackValues m_knockBack;
    [Tooltip("Controller ID player number")]
    public int PlayerNumber = 1;
    Transform enemy;

    Rigidbody2D rig2D;
    Animator anim;
    public int deathCounter;
    [HideInInspector]
    public float horizontal;
    float vertical;
    public float maxSpeed = 25; /// determines the movementspeed
    Vector3 movement;

    [HideInInspector]
    public bool up;
    [HideInInspector]
    public bool crouch;

    public int MaxBlockingCharge; /// determines how many charges the characters have
    [HideInInspector]
    public int blockCharge; /// current block charge

    public float BlockingRechargeTimer; ///Timetaken to recharge the blocking
    public float JumpForce = 20; ///force of jump
    public int m_FlapTimes; /// cool down forFlapping
    public int tempFlapTimes = 0;
    float jmpForce;

    [HideInInspector]
    public bool jumpKey; /// checking of jump
    bool falling; /// cheking of falling
    [HideInInspector]
    public bool onGround; /// checking on ground
    bool allowMovement; /// to allow movement

    public float attackRate = 0.3f; /// duration of checking of attack before setting bool to false
    bool[] attack = new bool[2]; /// cheking for as many attacks as i want just increase the array size
    float[] attacktimer = new float[2]; /// counter before the reset based on the attack rate
    [HideInInspector]
    public int[] timesPressed = new int[2]; /// counting for press of attacks

    //public float m_knockBack;
    public bool damage;
    public bool block;
    public bool OnBlock;
    public float noDamage = 1;
    float noDamageTimer;
    public float noblock;
    public bool CanMove = false;
    float MoveTimer = 0;
    float blockTimer = 0;
    public float RecheckTimer;


    [HideInInspector]
    public bool InAirAttack = false;
    //[HideInInspector]
    public bool CrouchAttack = false;
    [HideInInspector]
    public bool GetBlocked = false;

    public float m_FallingGravity;
    float m_OriginalGravity;



    void Awake()
    {
        Debug.Log(PlayerNumber);
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log(PlayerNumber);
        blockCharge = MaxBlockingCharge;
        m_knockBack = GetComponent<KnockBackValues>();

        rig2D = GetComponent<Rigidbody2D>();
        m_OriginalGravity = rig2D.gravityScale;

        anim = GetComponentInChildren<Animator>();

        jmpForce = JumpForce;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject pl in players)
        {
            if (pl.transform != this.transform)
            {
                enemy = pl.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal" + PlayerNumber.ToString());
        vertical = Input.GetAxis("Vertical" + PlayerNumber.ToString());

        if (CanMove == true)
        {

            if (Input.GetButton("Block" + PlayerNumber.ToString()) && crouch == false && up == false)
            {
                OnBlock = true;
            }
            else
            {
                OnBlock = false;
            }

            Vector3 movement = new Vector3(horizontal, 0, 0);
                   if (horizontal > 0)
                   {
                       transform.localScale = new Vector3(1, 1, 1);
                   }
                   else if (horizontal < 0)
                   {
                       transform.localScale = new Vector3(-1, 1, 1);
                   }
                   
            if (Input.GetButtonDown("Jump" + PlayerNumber.ToString()) && crouch == false)
            {
                if (!jumpKey)
                {
                    rig2D.velocity = new Vector2(rig2D.velocity.x, jmpForce);
                    jumpKey = true;
                }
                else if (tempFlapTimes < m_FlapTimes)
                {
                    rig2D.velocity = new Vector2(rig2D.velocity.x, jmpForce);
                    tempFlapTimes += 1;
                }
            }
            if (Input.GetButton("Jump" + PlayerNumber.ToString()) && crouch == false)
            {
                rig2D.gravityScale = m_FallingGravity;
            }
            else
            {
                rig2D.gravityScale = m_OriginalGravity;
            }

            //if (vertical > 0.1f)
            //{
            //    if (!jumpKey)
            //    {
            //        jmpDuration += Time.deltaTime;
            //        jmpForce += Time.deltaTime;

            //        if (jmpDuration < JumpDuration)
            //        {
            //            rig2D.velocity = new Vector2(rig2D.velocity.x, jmpForce);
            //        }
            //        else
            //        {
            //            jumpKey = true;
            //        }
            //    }
            //}

            if (onGround)
            {
                crouch = (vertical < -0.1f);
                up = (vertical > 0.5f);
                rig2D.gravityScale = m_OriginalGravity;
                tempFlapTimes = 0;
            }

            if (!onGround)
            {
                falling = true;
                up = false;
            }

            if (up)
            {
                movement.x = 0;
            }

            if (!crouch)
            {
                rig2D.AddForce(movement * maxSpeed);
            }
            //else
            //{
            //    rig2D.velocity = Vector3.zero;
            //}
            //ScaleCheck();
        }

        else if (CanMove == false)
        {
            MoveTimer += Time.deltaTime;
            RecheckMove();
        }

        // Debug.Log(MoveTimer + " " + PlayerNumber);
        AttackInput();
        Damage();
        Block();
        UpdateAnimator();
        BlockingRecharge();
    }

    void RecheckMove()
    {
        if (MoveTimer > RecheckTimer)
        {
            CanMove = true;
            MoveTimer = 0;
        }
    }

    public void ScaleCheck()
    {
        if (transform.position.x > enemy.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = Vector3.one;
    }


    void AttackInput()
    {
        if (Input.GetButtonDown("Attack1" + PlayerNumber.ToString()))
        {
            if (vertical > 0.1f && onGround)// used for the upattack
            {
                Debug.Log("up attack");
                if (transform.localScale.x > 0)
                {
                    rig2D.velocity = (new Vector2(20, JumpForce));
                }
                else
                {
                    rig2D.velocity = (new Vector2(-1 * 20, JumpForce));
                }
            }
            attack[0] = true;
            attacktimer[0] = 0;
            timesPressed[0]++;
        }

        if (attack[0])
        {
            attacktimer[0] += Time.deltaTime;

            if (attacktimer[0] > attackRate /*&& timesPressed[0] == 3*/)
            {
                Debug.Log("UndoAtack");
                attacktimer[0] = 0;
                attack[0] = false;
                timesPressed[0] = 0;

            }
        }


        //if (attack[1])
        //{
        //    attacktimer[1] += Time.deltaTime;
        //    if (attacktimer[1] > attackRate || timesPressed[1] >= 4)
        //    {
        //        attacktimer[1] = 0;
        //        attack[1] = false;
        //        timesPressed[1] = 0;
        //    }
        //}
    }

    void Damage()
    {
        if (GetBlocked == true)
        {
            noDamageTimer += Time.deltaTime;
            if (noDamageTimer > noDamage)
            {
                GetBlocked = false;
                Vector3 dir = enemy.position - transform.position;
                rig2D.AddForce(new Vector3(-dir.x * m_knockBack.GetBlocked.x, m_knockBack.GetBlocked.y, m_knockBack.GetBlocked.z));
            }
        }
        if (damage)
        {
            CanMove = false;
            noDamageTimer += Time.deltaTime;
            OnBlock = false;
            if (noDamageTimer > noDamage)
            {
                damage = false;
                noDamageTimer = 0;
                if (onGround)
                {
                    if (CrouchAttack == true)
                    {
                        Vector3 dir = enemy.position - transform.position;
                        rig2D.AddForce(new Vector3(-dir.x * m_knockBack.CrouchAttack.x, m_knockBack.CrouchAttack.y, m_knockBack.CrouchAttack.z));
                        Debug.Log("crouch Hit");
                    }
                    else if (InAirAttack == true)
                    {
                        Vector3 dir = enemy.position - transform.position;
                        rig2D.AddForce(new Vector3(-dir.x * m_knockBack.AirAttack.x, m_knockBack.AirAttack.y, m_knockBack.AirAttack.z));
                        Debug.Log("hit by air");
                    }
                    else
                    {
                        Vector3 dir = enemy.position - transform.position;
                        rig2D.AddForce(new Vector3(-dir.x * m_knockBack.IdleAttack.x, m_knockBack.IdleAttack.y, m_knockBack.IdleAttack.z));
                        Debug.Log("onground");
                    }
                    CrouchAttack = false;
                    InAirAttack = false;
                }

                if (!onGround)
                {
                    if (InAirAttack == true)
                    {
                        Vector3 dir = enemy.position - transform.position;
                        rig2D.AddForce(new Vector3(-dir.x * m_knockBack.AirAttack.x, m_knockBack.AirAttack.y, m_knockBack.AirAttack.z));
                        Debug.Log("hit by air");
                    }
                    else
                    {
                        Vector3 dir = enemy.position - transform.position;
                        rig2D.AddForce(new Vector3(-dir.x * m_knockBack.UpAttack.x, m_knockBack.UpAttack.y, m_knockBack.UpAttack.z));
                        Debug.Log("normal Air no more");
                    }
                    CrouchAttack = false;
                    InAirAttack = false;
                }
            }

        }
    }

    void Block()
    {
        if (block && blockCharge > 0 && OnBlock)
        {
            Vector3 dir = enemy.position - transform.position;
            rig2D.velocity = Vector3.zero;
            //rig2D.AddForce(new Vector3(-dir.x * m_knockBack.Block.x, m_knockBack.Block.y, m_knockBack.Block.z));
            noDamageTimer += Time.deltaTime;
            if (noDamageTimer > noblock)
            {
                block = false;
                noDamageTimer = 0;
                blockCharge--;
            }
        }
    }

    void BlockingRecharge()
    {
        if (blockCharge < MaxBlockingCharge)
        {
            blockTimer += Time.deltaTime;
            if (blockTimer >= BlockingRechargeTimer)
            {
                blockCharge++;
                blockTimer = 0;
            }
        }
    }

    void UpdateAnimator()
    {
        anim.SetBool("OnGround", this.onGround);
        anim.SetBool("Falling", this.falling);
        anim.SetBool("Crouch", crouch);
        anim.SetFloat("Movement", Mathf.Abs(horizontal));
        anim.SetBool("LookingUp", up);

        if (attack[0] == true)
            CanMove = false;
        anim.SetBool("Attack1", attack[0]);
        anim.SetInteger("AttackInt", timesPressed[0]);
        anim.SetBool("Blocking", OnBlock);
        //anim.SetInteger("AttackInt", timesPressed[0]);
    }

    public void ResetCharacter()
    {
        rig2D.velocity = Vector3.zero;
        this.onGround = true;
        this.falling = false;
        this.crouch = false;
        horizontal = 0;
        up = false;
        attack[0] = false;
        timesPressed[0] = 0;
        block = false;
        UpdateAnimator();
        damage = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = true;
            jumpKey = false;
            jmpForce = JumpForce;
            falling = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = false;
        }
    }

    public void HazardKnock(Vector3 m_HazardKnockBack, int HitDir)
    {
        CanMove = false;
        OnBlock = false;
        rig2D.AddForce(new Vector3(HitDir * m_HazardKnockBack.x, m_HazardKnockBack.y, m_HazardKnockBack.z));
    }
}
