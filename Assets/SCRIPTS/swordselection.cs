using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class swordselection : MonoBehaviour
{
    private List<GameObject> models;

    private int selectionIndex = 0;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject sword3;
    public GameObject sword4;
    public GameObject sword5;
    public GameObject sword6;
    public GameObject sword7;
    public GameObject sword8;
    public GameObject sword9;
    public GameObject highlight;

    public GameObject canplay;

    // Start is called before the first frame update
    private void Start()
    {
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        models[selectionIndex].gameObject.SetActive(true);
    }
   
    public void Select(int index)
    {
        if (index == selectionIndex)
            return;
        if(index < 0 || index >= models.Count) 
            return;
        models[selectionIndex].gameObject.SetActive(false);
        selectionIndex = index;
        models[selectionIndex].gameObject.SetActive(true);
    }
    public void Update()
    {
        if (coincounter.boughtironsword == false && highlight.transform.position == sword2.transform.position)
        {
            canplay.SetActive(false);
        }
        else
        {
            canplay.SetActive(true);    
        }
        
    }

    public void s1()
    {
        highlight.transform.position = sword1.transform.position;

    }
    public void s2()
    {
        
        highlight.transform.position = sword2.transform.position;
    }
    public void s3()
    {
        highlight.transform.position = sword3.transform.position;
    }
    public void s4()
    {
        highlight.transform.position = sword4.transform.position;
    }
    public void s5()
    {
        highlight.transform.position = sword5.transform.position;
    }
}
