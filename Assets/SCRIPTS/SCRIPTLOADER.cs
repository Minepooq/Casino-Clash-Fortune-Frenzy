using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPTLOADER : MonoBehaviour
{
    public Behaviour controller;
    public Behaviour movement;
    public Behaviour attack;

    // Start is called before the first frame update
    void Start()
    {
        
        movement.enabled = false;
        attack.enabled = false;
    }

    // Update is called once per frame
    public void playpress()
    {
           
        controller.enabled = true;
        movement.enabled = true;
        attack.enabled = true;
    }
}
