using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class sworddiscription : MonoBehaviour
{
    private List<GameObject> models;

    private int selectionIndex = 0;



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
        if (index < 0 || index >= models.Count)
            return;
        models[selectionIndex].gameObject.SetActive(false);
        selectionIndex = index;
        models[selectionIndex].gameObject.SetActive(true);
    }


}
