using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    
    public string itemName;
    public string itemDescription;
    public Sprite icon;

    public bool isUpgrade;
    [Header("Stats")]
    public int currentHealth;
    public int maxHealth;
    public int speed;
    public int damage;
    [Header("For Temporary Items")]
    public float itemDuration;
}
