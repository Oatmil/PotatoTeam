using UnityEngine;
using System.Collections;

public class player1Controler : MonoBehaviour {

    public int PlayerNumber = 1;
    Transform enemy;

    Rigidbody2D rig2D;
    Animator anim;
    public int deathCounter;
    [HideInInspector] public float horizontal;
    float vertical;
    public float maxSpeed = 25; // movesped
    Vector3 movement;
    bool crouch; // checking of crouch
    bool up;

    public float JumpForce = 20;   // force of jump
    float jmpForce;
    bool jumpKey; // checking of jump
    bool falling; // cheking of falling
    bool onGround; // checking on ground
    bool allowMovement; // to allow movement

    public float attackRate = 0.3f; // duration of checking of attack before setting bool to false
    bool[] attack = new bool [2]; // cheking for as many attacks as i want just increase the array size
    float[] attacktimer = new float[2]; // counter before the reset based on the attack rate
    int[] timesPressed = new int[2]; // counting for press of attacks

    public float m_knockBack;
    public bool damage;
    public bool block;
    public float noDamage = 1;
    float noDamageTimer;
    public float noblock;
	public bool CanMove = false;
	float MoveTimer = 0;

	// Use this for initialization
	void Start () {
        rig2D = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        jmpForce = JumpForce;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject pl in players)
        {
            if (pl.transform != this.transform)
            {
                enemy = pl.transform;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (CanMove) {
			horizontal = Input.GetAxis ("Horizontal" + PlayerNumber.ToString ());
			vertical = Input.GetAxis ("Vertical" + PlayerNumber.ToString ());
        
			Vector3 movement = new Vector3 (horizontal, 0, 0);

			if (Input.GetButtonDown ("Jump" + PlayerNumber.ToString ())) {
				if (!jumpKey) {
					rig2D.velocity = new Vector2 (rig2D.velocity.x, jmpForce);
					jumpKey = true;
				}
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

			if (onGround) {
				crouch = (vertical < -0.1f);
				up = (vertical > 0.5f);
			}

			if (!onGround ) {
				falling = true;
			}

            if(up)
            {
				movement.x = 0;
            }

			if (!crouch) {
				rig2D.AddForce (movement * maxSpeed);
			} else {
				rig2D.velocity = Vector3.zero;
			}
		}


		if (CanMove == false) {
			RecheckMove ();
		}
		if (CanMove == true) {
			ScaleCheck ();
		}
        AttackInput();
        Damage();
        Block();
        UpdateAnimator();

    }

	void RecheckMove()
	{
			MoveTimer += Time.deltaTime;
			if (MoveTimer > 0.6f) {
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
			if (Input.GetButtonDown ("Attack1" + PlayerNumber.ToString ())) {
				if (vertical > 0.1f && onGround) {
					Debug.Log ("fly hit");
					if (transform.position.x < enemy.position.x) {
						rig2D.velocity = (new Vector2 (20, JumpForce));
					} else {
						rig2D.velocity = (new Vector2 (-1 * 20, JumpForce));
					}
				}
				attack [0] = true;
				attacktimer [0] = 0;
				timesPressed [0]++;
			}

			if (attack [0]) {
				attacktimer [0] += Time.deltaTime;
				if (attacktimer [0] > attackRate || timesPressed [0] >= 4) {
					attacktimer [0] = 0;
					attack [0] = false;
					timesPressed [0] = 0;
				}
			}


			if (attack [1]) {
				attacktimer [1] += Time.deltaTime;
				if (attacktimer [1] > attackRate || timesPressed [1] >= 4) {
					attacktimer [1] = 0;
					attack [1] = false;
					timesPressed [1] = 0;
				}
			}
    }

    void Damage()
    {
        if (damage)
        {
            noDamageTimer += Time.deltaTime;

            if (noDamageTimer > noDamage)
			{
				damage = false;
				noDamageTimer = 0;
				if (onGround) {
					Vector3 dir = enemy.position - transform.position;
					rig2D.AddForce (new Vector3 (-dir.x* m_knockBack * 300, 300, 0));
				}

				if (!onGround)
				{
					Vector3 dir = enemy.position - transform.position;
					rig2D.AddForce(new Vector3(-dir.x* m_knockBack * 300, 200,0));
				}
            }

            


        }
    }

    void Block()
    {
        if (block)
        {
            rig2D.velocity = Vector3.zero;
            noDamageTimer += Time.deltaTime;
            if (noDamageTimer > noblock)
            {
                block = false;
                noDamageTimer = 0;
                
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

        anim.SetBool("Attack1", attack[0]);
		if (attack [0] == true)
			CanMove = false;
        anim.SetBool("Blocking", block);
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
}
