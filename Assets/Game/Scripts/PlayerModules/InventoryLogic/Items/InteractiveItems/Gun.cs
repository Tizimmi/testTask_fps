using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Inventory) + "/" + nameof(Gun) , fileName = "new_" + nameof(Gun))]
	public class Gun : InventoryItem
	{
		public KeyCode _zoomButton;
		
		public int _damage;
		public int _range;
		
		public int _magazineSize;
		public int InMagazineBullets { get; private set; }
		public int _remainingBullets;

		public float _reloadTime;
		
		public virtual void Reload() // можно въебать корутину
		{
			if(InMagazineBullets == _magazineSize)
				return;

			var bulletsToRefill = _magazineSize - InMagazineBullets;

			if (_remainingBullets < bulletsToRefill)
				return;

			InMagazineBullets = _magazineSize;
			_remainingBullets -= bulletsToRefill;
		}
		
		public virtual void Zoom(bool isZooming)
		{
			
		}
	}
}