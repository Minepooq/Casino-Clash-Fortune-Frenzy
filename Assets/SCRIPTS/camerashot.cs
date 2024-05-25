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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);
  
        if(distance < startdist)
        {
            timer += Time.deltaTime;
            if (timer > timerstart)
            {
                timer = 0;
                shoot();
            }
        }
        
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);   
    }
}
