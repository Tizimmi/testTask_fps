using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Inventory) + "/" + nameof(Gun) , fileName = "new_" + nameof(Gun))]
	public class Gun : Item
	{
		public int _magazineSize;
		public int _ammoStorage;
		
		public int _damage;
		public int _range;
		public float _fireCooldown;
		public float _reloadTime;
		
		public float _zoomValue;
	}
}