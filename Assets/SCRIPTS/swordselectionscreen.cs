using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class swordselectionscreen : MonoBehaviour
{
    private int quit = 0;
    public GameObject exit;
    public int scenenumber;
    public static bool playtrue;
    [SerializeField]
    public static GameObject sw;
    public GameObject grey;
    // Start is called before the first frame update

    public void Start()
    {
        sw = gameObject;
        gameObject.SetActive(false);
    }
    public void superman()
    {
        gameObject.SetActive(false);

    }


    public void quitgame()
    {
        if (quit == 1)
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