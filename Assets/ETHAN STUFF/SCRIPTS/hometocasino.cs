using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hometocasino : MonoBehaviour
{
    // an integer that takes the scene number from the build settings 
    public int scene1;
    // Start is called before the first frame update
     
    //EMPTY GAME OBJECT THAT CHECKS TAG IF CHARACHTER THEN SWITCH SCENE
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(scene1, LoadSceneMode.Single);
        }
    }
}
