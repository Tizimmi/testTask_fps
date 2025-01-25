using Game.Scripts.PlayerModules.HealthModule;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Gun : MonoBehaviour
	{
		[SerializeField]
		private int _damage, _range;
		
		public int _magazineSize;
		public int _inMagazineBullets;
		public int _remainingBullets;
		
		[SerializeField]
		private float _shotCooldownTime;
		[SerializeField]
		private float _reloadTime;
		[SerializeField]
		private float _gunZoom;
		
		private bool _isReloading;
		private float _shotCooldown;

		private Camera _camera;
		private float _defaultFOV;
		private bool _isZooming;

		private void Start()
		{
			_camera = Camera.main;
			
			if (_camera)
			{
				_defaultFOV = _camera.fieldOfView;
			}
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

			if (_inMagazineBullets <= 0)
			{
				Reload();
				return;
			}

			if (_shotCooldown > 0)
				return;

			_shotCooldown = _shotCooldownTime;
			
			Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

			Debug.Log($"SHOOT {_damage}");
			_inMagazineBullets--;
			
			if (Physics.Raycast(ray,
					out var hit,
					_range))
			{
				var healthComponent = hit.transform.gameObject.GetComponent<HealthComponent>();
				if(!healthComponent)
					return;
				healthComponent.TakeDamage(_damage);
			}
		}
		
		public void Reload()
		{
			if(_inMagazineBullets == _magazineSize)
				return;

			var bulletsToRefill = _magazineSize - _inMagazineBullets;

			if (_remainingBullets == 0)
				return;

			if (_remainingBullets < bulletsToRefill)
				bulletsToRefill = _remainingBullets;

			StartCoroutine(ReloadRoutine(bulletsToRefill));
		}

		private IEnumerator ReloadRoutine(int bulletsToRefill)
		{
			Debug.Log("Reload");
			_isReloading = true;

			yield return new WaitForSeconds(_reloadTime);
			
			_inMagazineBullets += bulletsToRefill;
			_remainingBullets -= bulletsToRefill;

			_isReloading = false;
		}
	}
}