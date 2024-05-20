using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthimage : MonoBehaviour
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
        if (script.playerhealth == 2)
        {
            heart.SetActive(false);
        }
    }
}
