using Game.Scripts.PlayerModules.InventoryLogic.Items;

namespace Game.Scripts.PlayerModules.InventoryLogic
{
	public class Inventory
	{
		private readonly Item[] _inventoryItems = new Item[5];
		
		public bool AddItem(Item item)
		{
			var newItem = (int) item._type;

			if (_inventoryItems[newItem] != null)
				return false;

			_inventoryItems[newItem] = item;
			return true;

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