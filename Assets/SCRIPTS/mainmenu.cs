using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class mainmenu : MonoBehaviour
{
    private int quit = 0;
    public GameObject exit;
    public int scenenumber;
    public static GameObject playtrue;
    public static bool istrue = true;
    // Start is called before the first frame update

    public void Start()
    {

    }

    public void playgame()
    {
        if(quit == 0)
        {
            istrue = false;
            SceneManager.UnloadSceneAsync(scenenumber);
            swordselectionscreen.sw.gameObject.SetActive(true);
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
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quit == 0)
            {

                Debug.Log("quit game?");
                quit = 1;
                exit.SetActive(true);
            }
            else
            {
                Debug.Log("no quit game");
                quit = 0;
                exit.SetActive(false);
            }

        }
    }
    public void exitexit()
    {
        quit = 0;
        exit.SetActive(false);
    }

}