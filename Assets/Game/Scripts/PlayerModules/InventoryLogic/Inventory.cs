using Game.Scripts.PlayerModules.InventoryLogic.Items;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField]
		private InventoryItem[] _inventoryItems;
		[SerializeField]
		private InventoryItem _test1;
		[SerializeField]
		private InventoryItem _test2;

		private void Start()
		{
			_inventoryItems = new InventoryItem[5];
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				AddItem(_test1);
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				AddItem(_test2);
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				RemoveItem(0);
			}
		}

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