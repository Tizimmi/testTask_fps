using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using System;
using UnityEngine;
using Zenject;
using InventoryItem = Game.Scripts.PlayerModules.InventoryLogic.Items.InventoryItem;

namespace Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic
{
	public class EquipmentModule : MonoBehaviour
	{
		public event Action<Gun> OnGunEquipped;
		
		[SerializeField]
		private HandItemModule _handItemModule;
		[Inject]
		private Inventory _inventory;
		
		private void Update()
		{
			InventoryItem item;
			
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (_inventory.TryGetItem(0, out item))
				{
					if (item.TryGetComponent(out Gun gun))
						OnGunEquipped?.Invoke(gun);
					
					_handItemModule.SetActiveItem(item);
					item.Equip();
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (_inventory.TryGetItem(1, out item))
				{
					if (item.TryGetComponent(out Gun gun))
						OnGunEquipped?.Invoke(gun);
					
					item.Equip();
					_handItemModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (_inventory.TryGetItem(2, out item))
				{
					if (item.TryGetComponent(out Gun gun))
						OnGunEquipped?.Invoke(gun);
					
					item.Equip();
					_handItemModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if (_inventory.TryGetItem(3, out item))
				{
					if (item.TryGetComponent(out Gun gun))
						OnGunEquipped?.Invoke(gun);
					
					item.Equip();
					_handItemModule.SetActiveItem(item);
					return;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				if (_inventory.TryGetItem(4, out item))
				{
					if (item.TryGetComponent(out Gun gun))
						OnGunEquipped?.Invoke(gun);
					
					item.Equip();
					_handItemModule.SetActiveItem(item);
					return;
				}
			}
		}
	}
}