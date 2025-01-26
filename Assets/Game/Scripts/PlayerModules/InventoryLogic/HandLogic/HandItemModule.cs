using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	public class HandItemModule : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;
		[SerializeField]
		private float _zoomValue;

		[Inject]
		private readonly Inventory _inventory;

		private InventoryItem _currentActiveItem;
		private bool _isZooming;
		private float _defaultFOV;

		private void Start()
		{
			_defaultFOV = _camera.fieldOfView;
		}

		private void Update()
		{
			if (!_currentActiveItem)
			{
				ResetZoom();
				return;
			}

			if (Input.GetButtonDown("Drop"))
			{
				_currentActiveItem.GetComponent<Pickup>().Drop();
				_inventory.RemoveItem(_currentActiveItem);
				_currentActiveItem = null;
				return;
			}

			if (Input.GetButtonDown("Fire1"))
			{
				if (_currentActiveItem.TryGetComponent(out Consumable consumable))
					consumable.Use();
			}

			if (!_currentActiveItem.TryGetComponent(out Gun gun))
			{
				ResetZoom();
				return;
			}

			if (Input.GetButtonDown("Fire1"))
			{
				gun.Shoot();
			}

			if (Input.GetButtonDown("Fire2"))
			{
				ToggleZoom();
			}

			if (Input.GetButtonDown("Reload"))
			{
				gun.Reload();
			}
		}

		public void SetActiveItem(InventoryItem item)
		{
			if (item == _currentActiveItem)
				return;

			if (_currentActiveItem)
				_currentActiveItem.UnEquip();

			_currentActiveItem = item;
		}

		private void ToggleZoom()
		{
			if (!_camera)
				return;

			if (_isZooming)
				ResetZoom();
			else
				ZoomIn(_zoomValue);
		}

		private void ZoomIn(float newFOV)
		{
			_camera.fieldOfView = newFOV;
			_isZooming = true;
		}

		private void ResetZoom()
		{
			_camera.fieldOfView = _defaultFOV;
			_isZooming = false;
		}
	}
}