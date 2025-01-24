using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items
{
	[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Inventory) + "/" + nameof(InventoryItem) , fileName = "new_" + nameof(InventoryItem))]

	public class InventoryItem : ScriptableObject
	{
		[SerializeField]
		public string _itemName;
		[SerializeField]
		public ItemType _itemType;
		[SerializeField]
		public GameObject _prefab;
		[field: SerializeField]
		public KeyCode UseButton { get; private set; }

		public virtual void Equip()
		{
			Debug.Log($"Equipped {_itemName}");
		}
		
		public virtual void Use()
		{
			Debug.Log($"Used {_itemName}");
		}
	}
}