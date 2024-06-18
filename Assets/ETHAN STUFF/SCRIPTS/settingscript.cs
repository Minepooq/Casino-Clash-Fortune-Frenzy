using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class settingscript : MonoBehaviour
{
    public GameObject allbuttons;
    public static int buttonsisactive = 0;
    public static bool quittomain = false;
    public static bool playerquit = false;  
    // Start is called before the first frame update

    void Start()
    {
        allbuttons.SetActive(false);   
    }

    public void buttonscreen()
    {
        Debug.Log(buttonsisactive);
        if(buttonsisactive == 0)
        {
            allbuttons.SetActive(true);
            buttonsisactive = 1;
        }
        else
        {
            allbuttons.SetActive(false);
            buttonsisactive = 0;
        }
    }
    public void quit()
    {
        quittomain = true;
        allbuttons.SetActive(false);
        buttonsisactive = 0;
        playerquit = true;
        playerattack.isrestart = true;

    }
    public void resume()
    {

        buttonsisactive = 0;
        allbuttons.SetActive(false);    

    }
    public void options()
    {

    }
}
