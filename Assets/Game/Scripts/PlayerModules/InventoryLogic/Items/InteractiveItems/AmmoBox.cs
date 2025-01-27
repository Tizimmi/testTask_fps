using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class AmmoBox : ConsumablePickup
	{
		[SerializeField]
		public int _ammoAmount;
		[SerializeField]
		public ItemType _ammoType;
		[Inject]
		private readonly Inventory _inventory;
		[Inject]
		private readonly Shooting _shooting;

		public override void Use()
		{
			if (!_canBeUsed)
				return;

			if (_shooting.TryAddAmmo(_ammoAmount, _ammoType))
			{
				_inventory.RemoveItem(_item);
				Destroy(gameObject);
			}
		}
	}
}