using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using System;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.HUD
{
	public class AmmoView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _ammoField;

		[SerializeField]
		private EquipmentModule _equipmentModule;

		private Gun _currentGun;

		private void OnEnable()
		{
			_equipmentModule.OnGunEquipped += UpdateReference;
		}

		private void OnDisable()
		{
			_equipmentModule.OnGunEquipped -= UpdateReference;
			if(_currentGun == null)
				return;
			_currentGun.OnAmmoChange -= UpdateAmmo;
			_currentGun.OnReload -= ShowReloadText;
		}

		private void UpdateReference(Gun gun)
		{
			if (_currentGun != null)
			{
				_currentGun.OnReload -= ShowReloadText;
				_currentGun.OnAmmoChange -= UpdateAmmo;
			}
			_currentGun = gun;

			_currentGun.OnReload += ShowReloadText;
			_currentGun.OnAmmoChange += UpdateAmmo;
			UpdateAmmo(_currentGun.InMagazineBullets, _currentGun.RemainingBullets);
		}

		private void UpdateAmmo(int inMagazine, int total)
		{
			_ammoField.text = $"{inMagazine}/{_currentGun.MagazineSize} ({total})";
		}

		private void ShowReloadText()
		{
			_ammoField.text = "Reloading";
		}
	}
}