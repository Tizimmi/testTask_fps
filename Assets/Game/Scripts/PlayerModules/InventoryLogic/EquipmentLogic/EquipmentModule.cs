using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using Game.Scripts.PlayerModules.InventoryLogic.Items;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic
{
	public class EquipmentModule : MonoBehaviour
	{
		[SerializeField]
		private HandItemModule _handModule;
		[SerializeField]
		private InventoryItem test;
		[SerializeField]
		private Transform _itemContainer;
		
		[Inject]
		private Inventory _inventory;

		private void Start()
		{
			_inventory.AddItem(test);
		}

		private void Update()
		{
			InventoryItem item;
			
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (_inventory.TryGetItem(0, out item))
				{
					item.Equip(_itemContainer);
					_handModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (_inventory.TryGetItem(1, out item))
				{
					item.Equip(_itemContainer);
					_handModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (_inventory.TryGetItem(2, out item))
				{
					item.Equip(_itemContainer);
					_handModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if (_inventory.TryGetItem(3, out item))
				{
					item.Equip(_itemContainer);
					_handModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				if (_inventory.TryGetItem(4, out item))
				{
					item.Equip(_itemContainer);
					_handModule.SetActiveItem(item);
					return;
				}
			}
		}
	}
}