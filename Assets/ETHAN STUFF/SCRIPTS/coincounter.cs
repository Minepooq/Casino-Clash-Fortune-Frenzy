using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class coincounter : MonoBehaviour
{
    public static coincounter instance;
    [SerializeField]
    private AudioClip money;

    private AudioSource audioSource;
    public Text coinText;
    public Text ironswordequip;
    public static int CurrentCoins = 0;
    public bool boughtironsword = false;
    // Start is called before the first frame update
    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {

        ironswordequip.text = "LOCKED";
        coinText.text = CurrentCoins.ToString();
    }
    public void buyironsword()
    {
        if(CurrentCoins >= 800 && boughtironsword == false)
        {
            
            
            boughtironsword = true;
            CurrentCoins -= 800;
            coinText.text = CurrentCoins.ToString();
            ironswordequip.text = "EQUIPPED";

        }
        
        
        
    }



    // Update is called once per frame
    public void IncreaseCoins()
    {
 
        CurrentCoins += 5;
        coinText.text = CurrentCoins.ToString();
    }
}
