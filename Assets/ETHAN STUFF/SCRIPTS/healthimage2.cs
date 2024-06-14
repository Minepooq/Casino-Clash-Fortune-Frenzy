using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthimage2 : MonoBehaviour
{
    private playerattack script;
    public GameObject heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (script.playerhealth == 0)
        {
            Debug.Log("PLAYER DIED");
            heart.SetActive(false); 
        }
    }
}
