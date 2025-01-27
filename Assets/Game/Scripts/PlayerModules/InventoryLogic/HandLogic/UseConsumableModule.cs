using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	public class UseConsumableModule : MonoBehaviour
	{
		[SerializeField]
		private EquipmentModule _equipmentModule;

		[Inject]
		private readonly Inventory _inventory;
		
		public void Update()
		{
			if(!_inventory.TryGetItem(_equipmentModule.CurrentItemSlotID, out var item))
				return;
			
			if (_equipmentModule._currentItemObject is not ConsumablePickup consumable)
				return;

			if (Input.GetButtonDown("Fire1"))
			{
				consumable.Use();
			}
				
		}
	}
}