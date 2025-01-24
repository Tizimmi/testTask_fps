using Game.Scripts.PlayerModules.InventoryLogic.Items;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic
{
	public class EquipmentModule : MonoBehaviour
	{
		private InventoryItem _equippedItem;
		
		[SerializeField]
		private Inventory _inventory;

		private void Update()
		{
			InventoryItem item = null;
			
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (_inventory.TryGetItem(0, out item))
					_equippedItem = item;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (_inventory.TryGetItem(1, out item))
					_equippedItem = item;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (_inventory.TryGetItem(2, out item))
					_equippedItem = item;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if (_inventory.TryGetItem(3, out item))
					_equippedItem = item;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				if (_inventory.TryGetItem(4, out item))
					_equippedItem = item;
			}

			if (item != null)
			{
				item.Equip();
			}
		}
	}
}