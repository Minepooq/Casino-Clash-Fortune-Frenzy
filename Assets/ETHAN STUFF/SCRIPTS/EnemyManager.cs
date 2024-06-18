using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    private Transform enemypos;
    public playerattack playerattack;
    // Start is called before the first frame update
    void Start()
    {
        enemypos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerattack.isrestart == true)
        {
            enemygen();
            playerattack.isrestart = false;
        }

    }

    public void enemygen()
    {
        Instantiate(enemy, enemypos.position, Quaternion.identity);
    }
}
