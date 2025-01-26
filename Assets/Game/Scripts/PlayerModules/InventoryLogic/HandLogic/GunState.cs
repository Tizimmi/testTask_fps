using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	[System.Serializable]
	public class GunState
	{
		public readonly Gun Gun;
		
		public int _currentMagazineFill;
		public int _currentAmmoStorage;

		public GunState(Gun gun)
		{
			Gun = gun;
			_currentMagazineFill = gun._magazineSize;
			_currentAmmoStorage = gun._ammoStorage;
		}
	}
}