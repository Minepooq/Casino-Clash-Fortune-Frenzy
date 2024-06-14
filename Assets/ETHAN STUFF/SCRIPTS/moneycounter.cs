using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moneycounter : MonoBehaviour
{
    

    public Transform Player;
    public float magnetrange;
    private bool magneton;
    public float magnetspeed;
    private bool cansee;
    [SerializeField]
    private float magnetwait;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, Player.position);
        if (magnetwait <= 0)
        {
            if (distToPlayer < magnetrange && cansee)
            {
                magneton = true;
            }
            else
            {
                magneton = false;
            }
            if (magneton)
            {
                transform.position = Vector2.Lerp(transform.position, Player.transform.position, magnetspeed * Time.deltaTime);
            }

        }
        else
        {
            magnetwait -= Time.deltaTime;
        }



    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
        if (ray.collider != null)
        {
            //if the raycast hits the player tag then just for refrence just draws ray and makes ray
            //if does not hit then jsut create a red 
            cansee = ray.collider.CompareTag("Player");
            if (cansee == true)
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.green);
            }
            if(cansee == false)
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red);
            }






        }
    }


    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        //uses collider 2d to check if ther "other" game object's tag is labeled player (only the player has this name tag)
        //destroys this game object (the coin)
            //then increase the coin counter value
            //your total coin value
        if (other.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            coincounter.instance.IncreaseCoins();
        }
    }

}
