using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class mainmenu : MonoBehaviour
{
    private int quit = 0;
    public GameObject exit;

    // Start is called before the first frame update
    public void playgame()
    {
        if(quit == 0)
        {
            SceneManager.LoadScene(0);

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