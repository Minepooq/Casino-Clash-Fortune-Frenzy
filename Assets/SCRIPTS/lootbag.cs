using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootbag : MonoBehaviour
{

    public GameObject droppedItemPrefab;
    public List<enemydrop> lootList = new List<enemydrop>();
    // Start is called before the first frame update
    
    enemydrop GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<enemydrop> possibleItems = new List<enemydrop>();
        foreach (enemydrop item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
                
                

            }
            
        }
        if(possibleItems.Count > 0)
        {
            enemydrop droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
       
        Debug.Log("no loot dropped");
        return null;


    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        enemydrop droppedItem = GetDroppedItem();
        if (droppedItem != null) 
        { 
            
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
        
        }

    }
}
