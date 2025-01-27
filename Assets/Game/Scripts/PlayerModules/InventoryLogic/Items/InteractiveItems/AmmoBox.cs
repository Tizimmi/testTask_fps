using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class AmmoBox : ConsumablePickup
	{
		[Inject]
		private readonly Shooting _shooting;
		[Inject]
		private readonly Inventory _inventory;
		[SerializeField]
		public int _ammoAmount;
		[SerializeField]
		public ItemType _ammoType;

		public override void Use()
		{
			if(!_canBeUsed)
				return;

			if (_shooting.TryAddAmmo(_ammoAmount, _ammoType))
			{
				_inventory.RemoveItem(_item);
				Destroy(gameObject);
			}
		}
	}
}