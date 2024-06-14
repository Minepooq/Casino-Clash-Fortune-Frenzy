using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public settingscript settingscript;
    public playerattack playerattack;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerattack.isrestart == true)
        {
            Debug.Log("works");
            enemy.SetActive(true); 
            playerattack.isrestart = false; 
        }

    }
}
