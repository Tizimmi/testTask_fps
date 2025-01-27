﻿using Game.Scripts.PlayerModules.HealthModule;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using Game.Scripts.UI.HUD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	public class Shooting : MonoBehaviour
	{
		[SerializeField]
		private EquipmentModule _equipmentModule;

		[Inject]
		private readonly Inventory _inventory;
		[Inject]
		private readonly AmmoView _ammoView;
		[Inject]
		private Camera _camera;
		private float _lastShotTime;

		private bool _isReloading;
		private bool _canShoot;
		
		[SerializeField]
		private List<GunState> _gunStates = new();
		
		private bool _isZooming;
		private float _defaultFOV;

		private void Start()
		{
			if (_camera != null)
				_defaultFOV = _camera.fieldOfView;
		}

		public void Update()
		{
			if (!_inventory.TryGetItem(_equipmentModule.CurrentItemSlotID, out var item))
				return;

			if (item is not Gun gun)
			{
				return;
			}
			
			GunState gunState = GetOrCreateGunState(gun);

			if (gunState._currentMagazineFill <= 0)
				Reload(gun, gunState);

			TryShoot(gunState);

			if (!_canShoot)
				return;

			if (Input.GetButton("Fire1"))
			{
				Shoot(gun, gunState);
			}

			if (Input.GetButtonDown("Reload"))
			{
				Reload(gun, gunState);
			}

			if (Input.GetButtonDown("Fire2"))
			{
				ToggleZoom(gun);
			}
		}

		public GunState GetOrCreateGunState(Gun gun)
		{
			var existingState = _gunStates.Find(state => state.Gun == gun);

			if (existingState != null)
			{
				return existingState;
			}

			var newState = new GunState(gun);
			_gunStates.Add(newState);
			return newState;
		}

		private void TryShoot(GunState gunState)
		{
			_canShoot = !_isReloading && gunState._currentMagazineFill > 0;
		}

		private void Shoot(Gun gun, GunState gunState)
		{
			if (Time.time > _lastShotTime + gun._fireCooldown)
			{
				_lastShotTime = Time.time;
				ShootRay(gun);
				UseAmmo(gun, gunState);
			}
		}

		private void UseAmmo(Gun gun, GunState gunState)
		{
			gunState._currentMagazineFill--;
			UpdateAmmoView(gunState, gun);
		}

		public bool TryAddAmmo(int amount, ItemType type)
		{
			var selected = _gunStates.Find(x => x.Gun._type == type);
			if (selected == null)
				return false;
			selected.AddAmmo(amount);
			return true;
		}

		private void ShootRay(Gun gun)
		{
			Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / (float) 2, Screen.height / (float) 2));

			if (Physics.Raycast(ray, out var hit, gun._range))
			{
				var healthComponent = hit.transform.gameObject.GetComponent<HealthComponent>();
				if (!healthComponent)
					return;

				healthComponent.TakeDamage(gun._damage);
			}
		}

		private void Reload(Gun gun, GunState gunState)
		{
			if (_isReloading)
				return;

			if (gunState._currentMagazineFill == gun._magazineSize)
				return;

			var bulletsToRefill = gun._magazineSize - gunState._currentMagazineFill;

			if (gunState._currentAmmoStorage == 0)
				return;

			if (gunState._currentAmmoStorage < bulletsToRefill)
				bulletsToRefill = gunState._currentAmmoStorage;

			StartCoroutine(ReloadCoroutine(gun, gunState, bulletsToRefill));
		}

		private IEnumerator ReloadCoroutine(Gun gun, GunState gunState, int bulletsToRefill)
		{
			_isReloading = true;
			_ammoView.SetReloadState();

			yield return new WaitForSeconds(gun._reloadTime);

			gunState._currentMagazineFill += bulletsToRefill;
			gunState._currentAmmoStorage -= bulletsToRefill;

			UpdateAmmoView(gunState, gun);

			_isReloading = false;
		}

		private void UpdateAmmoView(GunState gunState, Gun gun)
		{
			_ammoView.UpdateAmmo(gunState._currentMagazineFill, gun._magazineSize, gunState._currentAmmoStorage);
		}
		
		private void ToggleZoom(Gun gun)
		{
			if (!_camera)
				return;

			if (_isZooming)
				ResetZoom();
			else
				ZoomIn(gun._zoomValue);
		}

		private void ZoomIn(float newFOV)
		{
			_camera.fieldOfView = newFOV;
			_isZooming = true;
		}

		public void ResetZoom()
		{
			_camera.fieldOfView = _defaultFOV;
			_isZooming = false;
		}
	}
}