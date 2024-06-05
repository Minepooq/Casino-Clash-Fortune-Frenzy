using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public int playerhealth = 3;
    public AudioSource AudioSource;
    public AudioClip attackSound;
    public float timeBtwAttack = 0f;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public Transform playerdestroy;
    public LayerMask enemyLayer;
    public float attackRange;
    public int Damage;
    public Animator animator;
    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;
    public Animator playerhurt;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage(int Damage)
    {

        playerhealth -= Damage;
        playerhurt.SetTrigger("takedamage");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth == 4)
        {
            heart.SetActive(false);
        }
        if (playerhealth == 2)
        {
            heart1.SetActive(false);
        }
        if (playerhealth == 0)
        {
            heart2.SetActive(false);
        }
        if (playerhealth <= 0)
        {
            gameObject.SetActive(false);
        }
        
        
       
        
        
        
        
    }
    


}
