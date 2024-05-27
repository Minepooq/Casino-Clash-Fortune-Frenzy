using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashot : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletpos;
    private GameObject player;
    private float timer;
    public float startdist = 4;
    public float timerstart;
    private bool cansee = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);
  
        if(distance < startdist && cansee == true)
        {
            animator.SetBool("cansee", true);
            timer += Time.deltaTime;
            if (timer > timerstart)
            {
                
                timer = 0;
                shoot();
            }
        }
        else
        {
            animator.SetBool("cansee", false);
        }
        
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);   
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {

            cansee = ray.collider.CompareTag("Player");
            if (cansee == true)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            if (cansee == false)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }






        }
    }
}
