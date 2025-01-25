using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items
{
	public class InventoryItem : MonoBehaviour
	{
		[SerializeField]
		public string _itemName;
		[SerializeField]
		public ItemType _itemType;
		
		public virtual void Equip()
		{
			gameObject.SetActive(true);
		}
		
		public virtual void UnEquip()
		{
			gameObject.SetActive(false);
		}
	}
}