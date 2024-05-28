using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordselection : MonoBehaviour
{
    public GameObject sword;
    public GameObject sword2;
    public GameObject sword3;
    public GameObject sword4;
    public GameObject sword5;
    public GameObject sword6;
    public GameObject sword7;
    public GameObject sword8;
    public GameObject sword9;
    public GameObject highlight;
    // Start is called before the first frame update
    void Start()
    {
        highlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void s1()
    {
        highlight.SetActive(true); 
        highlight.transform.position = sword.transform.position;
    }
    public void s2()
    {
        highlight.SetActive(true);
        highlight.transform.position = sword2.transform.position;
    }
    public void s3()
    {
        highlight.SetActive(true);
        highlight.transform.position = sword3.transform.position;
    }



}
