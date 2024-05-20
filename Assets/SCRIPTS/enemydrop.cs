using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class enemydrop : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public enemydrop(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;


    }
}
