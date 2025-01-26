using Game.Scripts.PlayerModules.HealthModule;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Gun : MonoBehaviour
	{
		public event Action<int, int> OnAmmoChange;
		public event Action OnReload;

		[field: SerializeField]
		public int MagazineSize { get; private set; }
		[field: SerializeField]
		public int MaxAmmo { get; private set; }
		
		[SerializeField]
		private int _damage, _range;
		[SerializeField]
		private LayerMask _hittableLayers;
		
		public int InMagazineBullets { get; private set; }
		public int RemainingBullets { get; private set; }
		
		[SerializeField]
		private float _shotCooldownTime;
		[SerializeField]
		private float _reloadTime;
		
		private bool _isReloading;
		private float _shotCooldown;
		private Camera _camera;

		private void Start()
		{
			_camera = Camera.main;
			InMagazineBullets = MagazineSize;
			RemainingBullets = MaxAmmo;
		}

		private void OnEnable()
		{
			_isReloading = false;
		}

		private void Update()
		{
			if (_shotCooldown > 0)
				_shotCooldown = Mathf.Max(_shotCooldown - Time.deltaTime, 0);
		}

		public void Shoot()
		{
			if(_isReloading)
				return;

			if (InMagazineBullets <= 0)
			{
				Reload();
				return;
			}

			if (_shotCooldown > 0)
				return;

			_shotCooldown = _shotCooldownTime;
			
			Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
			
			InMagazineBullets--;
			
			OnAmmoChange?.Invoke(InMagazineBullets, RemainingBullets);
			
			if (Physics.Raycast(ray,
					out var hit, _range,
					_hittableLayers))
			{
				
				var healthComponent = hit.transform.gameObject.GetComponent<HealthComponent>();
				if(!healthComponent)
					return;
				healthComponent.TakeDamage(_damage);
			}
		}
		
		public void Reload()
		{
			if(InMagazineBullets == MagazineSize)
				return;

			var bulletsToRefill = MagazineSize - InMagazineBullets;

			if (RemainingBullets == 0)
				return;

			if (RemainingBullets < bulletsToRefill)
				bulletsToRefill = RemainingBullets;

			StartCoroutine(ReloadRoutine(bulletsToRefill));
		}

		private IEnumerator ReloadRoutine(int bulletsToRefill)
		{
			_isReloading = true;
			
			OnReload?.Invoke();
			
			yield return new WaitForSeconds(_reloadTime);
			
			InMagazineBullets += bulletsToRefill;
			RemainingBullets -= bulletsToRefill;

			_isReloading = false;
			
			OnAmmoChange?.Invoke(InMagazineBullets, RemainingBullets);
		}

		private void OnDisable()
		{
			OnAmmoChange = null;
			OnReload = null;
		}
	}
}