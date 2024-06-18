using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerattack : MonoBehaviour
{
    public GameObject thisgameobjectpleaseworkdaddy;
    public int playerhealth = 3;
    public float timeBtwAttack = 0f;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public Transform playerdestroy;
    public LayerMask enemyLayer;
    public float attackRange;
    public int Damage;
    public GameObject youdied;
    public Animator animator;
    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;
    public Animator playerhurt;
    public GameObject startpos;
    public mainmenu script;
    public static bool dead = false;
    public GameObject youdiedscreen;
    private bool isyoudiedscreenactive = false;
    public static bool isrestart = false;
    // Start is called before the first frame update
    void Start()
    {
        
        youdiedscreen.SetActive(false);
        youdied.SetActive(false);
        thisgameobjectpleaseworkdaddy = GetComponent<GameObject>();
    }
    public void TakeDamage(int Damage)
    {

        playerhealth -= Damage;
        playerhurt.SetTrigger("takedamage");


    }

    // Update is called once per frame
    void Update()
    {
        if (isyoudiedscreenactive == true)
        {
            youdiedscreen.SetActive(true);
            isyoudiedscreenactive = false;
        }
        else
        {
            youdiedscreen.SetActive(false);
        }
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
            dead = true;
            isyoudiedscreenactive = true;
            
        }
        if(settingscript.playerquit == true)
        {
            gameObject.transform.position = startpos.transform.position;
            settingscript.playerquit = false;
        }
    
    }
    public void quitactualgame()
    {

        Application.Quit();
    }
    public void mainmenu()
    {
        youdiedscreen.SetActive(false);
        isyoudiedscreenactive = true;
        gameObject.transform.position = startpos.transform.position;
        settingscript.quittomain = true;
        restartlevel();
        isrestart = true;
    }
    

    public void restartlevel()
    {
        isyoudiedscreenactive = true;
        playerhealth = 6;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart.SetActive(true);
        gameObject.transform.position = startpos.transform.position;
        isrestart = true;
    }

}
