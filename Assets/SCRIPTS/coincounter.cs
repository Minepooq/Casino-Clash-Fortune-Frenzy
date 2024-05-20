using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coincounter : MonoBehaviour
{
    public static coincounter instance;

    public TMP_Text coinText;
  
    private int CurrentCoins = 0;
    // Start is called before the first frame update
    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coinText.text = CurrentCoins.ToString();
    }

    // Update is called once per frame
    public void IncreaseCoins()
    {
        CurrentCoins += 5;
        coinText.text = CurrentCoins.ToString();
    }
}
