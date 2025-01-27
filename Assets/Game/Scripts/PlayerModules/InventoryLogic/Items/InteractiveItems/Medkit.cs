using Game.Scripts.PlayerModules.HealthModule;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Medkit : ConsumablePickup
	{
		[SerializeField]
		private int _healingValue;
		[Inject]
		private readonly Inventory _inventory;
		
		[Inject]
		private readonly HealthComponent _health;
		
		public override void Use()
		{
			if(!_canBeUsed)
				return;

			if (_health.TryHeal(_healingValue))
			{
				_inventory.RemoveItem(_item);
				Destroy(gameObject);
			}	
		}
	}
}