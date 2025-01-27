using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	[System.Serializable]
	public class GunState
	{
		public int _currentMagazineFill;
		public int _currentAmmoStorage;
		public readonly Gun Gun;

		public GunState(Gun gun)
		{
			Gun = gun;
			_currentMagazineFill = gun._magazineSize;
			_currentAmmoStorage = gun._ammoStorage;
		}

		public void AddAmmo(int amount)
		{
			_currentAmmoStorage = Mathf.Min(_currentAmmoStorage + amount, Gun._ammoStorage);
		}
	}
}