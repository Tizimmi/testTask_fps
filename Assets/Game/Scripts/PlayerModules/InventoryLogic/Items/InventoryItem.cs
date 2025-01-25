using Unity.Mathematics;
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
			Debug.Log($"Equipped {_itemName}");
			gameObject.SetActive(true);
		}
		
		public virtual void UnEquip()
		{
			gameObject.SetActive(false);
		}
	}
}