using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetScript : MonoBehaviour
{
    public int balance  = coincounter.CurrentCoins;
    private int bet = 20;

    
    
    
    
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        
    }
    private void Update(){
        
        balance = coincounter.CurrentCoins; 
    }

    public int setBalance(int n){
        balance = n;
        return balance;
    }
    public int getBalance(){
        return balance;
    }
    public int setBet(int n){
        bet = n;
        return bet;
    }
}
