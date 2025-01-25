using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Gun : MonoBehaviour
	{
		public int _damage;
		public int _range;
		
		public int _magazineSize;
		public int InMagazineBullets { get; private set; }
		public int _remainingBullets;

		public float _reloadTime;

		public void Shoot()
		{
			Debug.Log($"Shooting for {_damage}");
		}
		
		public void Reload() // можно въебать корутину
		{
			if(InMagazineBullets == _magazineSize)
				return;

			var bulletsToRefill = _magazineSize - InMagazineBullets;

			if (_remainingBullets < bulletsToRefill)
				return;

			InMagazineBullets = _magazineSize;
			_remainingBullets -= bulletsToRefill;
		}
		
		public void Zoom()
		{
			
		}
	}
}