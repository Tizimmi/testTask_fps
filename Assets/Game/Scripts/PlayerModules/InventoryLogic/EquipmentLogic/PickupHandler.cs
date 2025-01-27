using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic
{
	public class PickupHandler : MonoBehaviour
	{
		[SerializeField]
		private LayerMask _pickupLayer;
		[SerializeField]
		private float _pickupRange;
		[Inject]
		private Camera _camera;
		[Inject]
		private Inventory _inventory;

		private void Update()
		{
			if (Input.GetButtonDown("Take"))
				PickUp();
		}

		private void PickUp()
		{
			var ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

			if (Physics.Raycast(ray,
					out var hit,
					_pickupRange,
					_pickupLayer))
				if (hit.transform.TryGetComponent(out Pickup pickup))
					if (_inventory.AddItem(pickup._item))
						Destroy(hit.transform.gameObject);
		}
	}
}