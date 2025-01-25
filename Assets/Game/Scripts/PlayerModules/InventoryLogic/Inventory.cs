using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic
{
	public class Inventory
	{
		private readonly InventoryItem[] _inventoryItems = new InventoryItem[5];
		
		public void AddItem(InventoryItem item)
		{
			var newItem = (int) item._itemType;
			
			if (_inventoryItems[newItem] == null)
			{
				_inventoryItems[newItem] = item;
			}
			else
			{
				Debug.Log("Slot is occupied");
			}
		}

		public void RemoveItem(int index)
		{
			_inventoryItems[index] = null;
		}

		public void RemoveItem(InventoryItem item)
		{
			RemoveItem((int)item._itemType);
		}

		public bool TryGetItem(int index, out InventoryItem item)
		{
			item = GetItem(index);
			return item != null;
		}

		public InventoryItem GetItem(int index)
		{
			return _inventoryItems[index];
		}
	}
}