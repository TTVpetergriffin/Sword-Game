using UnityEngine;

public class loot : MonoBehaviour
{
	public ItemSO itemSO;
	public Animator anim;

	public int quantity;

	private void OnValidate()
	{
		if (itemSO == null)
			return;

		this.name = itemSO.itemName;
	}
}
