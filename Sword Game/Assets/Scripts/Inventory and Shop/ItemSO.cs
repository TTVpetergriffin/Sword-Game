using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
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
}
