using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybulletscript : MonoBehaviour
{
    public int Damage = 2;
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private playerattack script;
    private bool cansee = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;   

        float rot = MathF.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cansee == true)
        {
            Debug.Log(1);
            Destroy(gameObject);
            collision.gameObject.GetComponent<playerattack>().playerhealth -= Damage;
            
        }
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
