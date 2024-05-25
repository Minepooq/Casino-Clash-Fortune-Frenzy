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
        if (collision.gameObject.CompareTag("Player"))
        {
           
            Destroy(gameObject);
            collision.gameObject.GetComponent<playerattack>().playerhealth -= Damage;
            
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            
            Destroy(gameObject);
            

        }
    }

    
}
