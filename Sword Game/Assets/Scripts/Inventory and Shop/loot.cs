using UnityEngine;

public class loot : MonoBehaviour
{
	public ItemSO itemSO;
	public Animator anim;
	public SpriteRenderer sr;

	public int quantity;

	private void OnValidate()
	{
		if (itemSO == null)
		{
			return:
		}
		sr.sprite = itemSO.icon;
		this.name = itemS0.itemName;
}
