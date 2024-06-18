using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;






//FIRST GET THE DISTANCE BETWEEN THE PLAYER AND THE OBJECT
//THEN USE AGRO RANGE WHICH IS A VALUE THAT U CAN SET YOURSELF TO DETECT WETHER THE PLAYER IS IN THAT RANGE
//IF THE PLAYER IS IN THAT RANGE THEN CHASE PLAYER AND IF NOT THEN DONT CHASE PLAYER
//CHASE PLAYER USES THE X POSITION OF THE OBJECT AND THE PLAYER AND SAYS THAT IF THE OBJECTS X POSITION IS NOT == TO PLAYER THEN PROCCED TO CHASE
//WHICH USES ANOTHER VALUE THAT YOU CAN SET WHICH IS THE MOVE SPEED

public class ENEMYAI : MonoBehaviour
{
    
    [SerializeField]
    Transform Player;

    [SerializeField]
    Transform knockback;

    [SerializeField]
    float agroRange;

  
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float mspeed;

    Rigidbody2D rb2d;

    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private float knockbackForcex;

    [SerializeField]
    private float knockbackForcey;

    [SerializeField]
    public float bounceSpeed;

    [SerializeField]
    private AudioClip damageSoundClip;

    private AudioSource audioSource;

    public Transform[] patrolPoints;

    public int patrolDestination;

    private bool isHit = false;

    public float enemyhp;

    private enemydropp script;
    Vector2 m_NewForce;

    private float knockback_direction;


    private bool damageTaken = false;

    public float knockbacktime;

    public GameObject coinn;

    public float coinheight;

    public float gravity;
    public int TEST;
    public Animator enemyhurt;

    public static GameObject enemy;
    // Start is called before the first frame update

    
    
    void Start()
    {
        enemy = GetComponent<GameObject>();
        enemyhurt = GetComponent<Animator>();
        coinn.SetActive(false);

        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int Damage)
    {
        m_NewForce = new Vector2(knockback_direction * knockbackForcex, knockbackForcey);
        rb2d.AddForce(m_NewForce, ForceMode2D.Impulse);

        enemyhp -= Damage;
        //creates a log just to check if hit or not

        damageTaken = true;
        knockbacktime = 0.5f;
        enemyhurt.SetTrigger("hit");
        audioSource.clip = damageSoundClip;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyhp > 0)
        {
            gameObject.SetActive(true); 
        }
        if(playerattack.isrestart == true)
        {
            enemyhp = 6; 
        }
        
        if (enemyhp <= 0)
        {
            Debug.Log("whynowork");
            gameObject.SetActive(false);

            //GetComponent<lootbag>().InstantiateLoot(transform.position);

            coinn.SetActive(true);

            coinn.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            
        }

        //distance to player (enemy position and player position)
        float distToPlayer = Vector2.Distance(transform.position, Player.position);

        //if the distance to player is less than the set agro range value and also if the raycast hits player then chase player
        //if not then don't chase
        if (damageTaken == false && knockbacktime <= 0)
        { 
            


            if (distToPlayer < agroRange && isHit == true)
            {

                ChasePlayer();
            }

            else
            {

                StopChasePlayer();
            }
            
        }
        else
        {
            if (knockbacktime > 0)
            {
                knockbacktime -= Time.deltaTime;
                damageTaken = false;
                
            }
            

        }

    }
   
    void ChasePlayer()
    {
        //this is the chasing player code 

        
        if (isHit && damageTaken == false)
        {
            
            //if the enemy is on the left of the player then move towards the player using the variable moveSpeed (takes in a positive float)
            if (transform.position.x < Player.position.x)
            {
                knockback_direction = -1;
                
                rb2d.velocity = new Vector2(moveSpeed, 0);
                //flips
                transform.localScale = new Vector2(-1, 1);
                //transforms the charachter's scale by negitive 1 so that if flips

            }
            else if (transform.position.x > Player.position.x)
            {
                knockback_direction = 1;
                //if on right then chase the player but use (-moveSpeed as moveSpeed is a positive float)
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
            }
        }


        
    }
    void StopChasePlayer()
    {
        //uses the patrol function instead of just stop chasing the player
        //takes which patrol destination the enemy is going to
        
            if (patrolDestination == 0)
            {
                //takes the position of the enemy (transform.position) and creates a new Vector 2(2 points as in (x, y)) and makes the player
                //move towards the patrol position
                //(Time.deltaTime makes it so that it goes off actual time and not due to frame rate (faster frame rate more updates so faster patrolling)
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, mspeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 1f)
                {
                    //flips player(and if the enemy reaches the position 0 then change the position to 1 and repeat
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }

            }
            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, mspeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 1f)
                {
                    
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                    

            }

            }

        

    }
     

    private void FixedUpdate()
    {
        //raycast
        //makes a raycast that takes in the enemy position and then the distance between the player and the enemy and creates a raycast between them


        //this is main function for raycast
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
        if(ray.collider != null)
        {
            //if the raycast hits the player tag then just for refrence just draws ray and makes ray
            //if does not hit then jsut create a red 
            isHit = ray.collider.CompareTag("Player");
            
            if (isHit == true) 
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.green);

                
            }
            if (isHit == false)
            {
                
                
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red);
                
                if(transform.position.x > Player.position.x && patrolDestination == 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }


            


        }
    }
    








}
