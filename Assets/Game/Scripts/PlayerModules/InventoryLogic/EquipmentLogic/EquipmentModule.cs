using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using Game.Scripts.UI.HUD;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic
{
	public class EquipmentModule : MonoBehaviour
	{
		[Inject]
		private Inventory _inventory;
		[Inject]
		private AmmoView _ammoView;
		[Inject]
		private Shooting _shooting;
		[SerializeField]
		private Transform _handSlot;

		public int CurrentItemSlotID { get; private set; }
		
		private Pickup _currentItemObject;

		private void Update()
		{
			Item item;
			
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (_inventory.TryGetItem(0, out item))
				{
					EquipItem(item);
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (_inventory.TryGetItem(1, out item))
				{
					EquipItem(item);
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (_inventory.TryGetItem(2, out item))
				{
					EquipItem(item);
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if (_inventory.TryGetItem(3, out item))
				{
					EquipItem(item);
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				if (_inventory.TryGetItem(4, out item))
				{
					EquipItem(item);
				}
			}
		}

		private void EquipItem(Item item)
		{
			if(_currentItemObject)
				UnEquipItem();
			
			_currentItemObject = Instantiate(item._prefab, _handSlot).GetComponent<Pickup>();
			_currentItemObject.Enable();
			
			CurrentItemSlotID = (int)_currentItemObject._item._type;

			if (item is Gun gun)
			{
				var gunState = _shooting.GetOrCreateGunState(gun);
				_ammoView.UpdateAmmo(gunState._currentMagazineFill, gun._magazineSize, gunState._currentAmmoStorage);
				_shooting.ResetZoom();
			}
			else
			{
				_ammoView.ResetText();
			}
		}

		private void UnEquipItem()
		{
			Destroy(_currentItemObject.gameObject);
		}
	}
}