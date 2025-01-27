using Game.Scripts.Global;
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
		public int CurrentItemSlotID { get; private set; }

		public Pickup _currentItemObject;
		[SerializeField]
		private Transform _handSlot;
		[Inject]
		private AmmoView _ammoView;

		[Inject]
		private Inventory _inventory;
		[Inject]
		private GamePrefabFactory _prefabFactory;
		[Inject]
		private Shooting _shooting;

		private void Update()
		{
			Item item;

			if (Input.GetKeyDown(KeyCode.Alpha1))
				if (_inventory.TryGetItem(0, out item))
					EquipItem(item);

			if (Input.GetKeyDown(KeyCode.Alpha2))
				if (_inventory.TryGetItem(1, out item))
					EquipItem(item);

			if (Input.GetKeyDown(KeyCode.Alpha3))
				if (_inventory.TryGetItem(2, out item))
					EquipItem(item);

			if (Input.GetKeyDown(KeyCode.Alpha4))
				if (_inventory.TryGetItem(3, out item))
					EquipItem(item);

			if (Input.GetKeyDown(KeyCode.Alpha5))
				if (_inventory.TryGetItem(4, out item))
					EquipItem(item);

			if (Input.GetKeyDown(KeyCode.Q))
				DropItem();
		}

		private void EquipItem(Item item)
		{
			if (_currentItemObject)
				UnEquipItem();

			_currentItemObject = _prefabFactory.InstantiatePrefab<Pickup>(item._prefab, _handSlot);
			_currentItemObject.Enable();

			CurrentItemSlotID = (int) _currentItemObject._item._type;

			if (item is Gun gun)
			{
				var gunState = _shooting.GetOrCreateGunState(gun);
				_ammoView.UpdateAmmo(gunState._currentMagazineFill, gun._magazineSize, gunState._currentAmmoStorage);
			}
			else
			{
				_ammoView.ResetText();
			}
		}

		private void UnEquipItem()
		{
			_shooting.ResetZoom();

			if (!_inventory.TryGetItem(CurrentItemSlotID, out var item))
				return;

			if (item is Gun)
				_shooting.StopReload();

			Destroy(_currentItemObject.gameObject);
		}

		private void DropItem()
		{
			_shooting.ResetZoom();

			if (!_currentItemObject)
				return;

			if (_inventory.TryGetItem(CurrentItemSlotID, out var item))
				if (item is Gun)
					_shooting.StopReload();

			_currentItemObject.Drop();
			_ammoView.ResetText();
			_inventory.RemoveItem(CurrentItemSlotID);
		}
	}
}