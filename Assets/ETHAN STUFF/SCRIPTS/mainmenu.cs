using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class mainmenu : MonoBehaviour
{
    public int quit = 0;
    public GameObject exit;
    public int scenenumber;
    public static GameObject playtrue;
    public static bool istrue = true;
    public GameObject title;
    public GameObject playbutton;
    // Start is called before the first frame update

    public void Start()
    {

    }

    public void playgame()
    {
        if(quit == 1)
        {
            title.gameObject.SetActive(false);
            playbutton.gameObject.SetActive(false); 
            istrue = false;
            //SceneManager.UnloadSceneAsync(scenenumber);
            swordselectionscreen.sw.gameObject.SetActive(true);
            Debug.Log("test");

        }
        
    }
    
    
    public void quitgame()
    {
        if(quit == 1)
        {
            Application.Quit();
            Debug.Log("quitgame");
        }
        
    }
    
    public void Update()
    {
        if (settingscript.quittomain == true)
        {
            title.gameObject.SetActive(true);
            playbutton.gameObject.SetActive(true);
            settingscript.quittomain = false;
            istrue = true;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(quit);
            if (quit == 1)
            {
                exit.SetActive(true);
                quit = 0;

            }
            else
            {

                exit.SetActive(false);
                quit = 1;
                
            }

        }
    }
    public void exitexit()
    {
        quit = 0;
        exit.SetActive(false);
    }

}