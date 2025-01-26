using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic
{
	public class Inventory
	{
		private readonly Item[] _inventoryItems = new Item[5];
		
		public void AddItem(Item item)
		{
			var newItem = (int) item._type;
			
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

		public void RemoveItem(Item item)
		{
			RemoveItem((int)item._type);
		}

		public bool TryGetItem(int index, out Item item)
		{
			item = GetItem(index);
			return item != null;
		}

		public Item GetItem(int index)
		{
			return _inventoryItems[index];
		}
	}
}