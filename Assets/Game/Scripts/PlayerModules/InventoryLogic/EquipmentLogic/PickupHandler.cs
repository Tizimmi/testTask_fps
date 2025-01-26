using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic
{
	public class PickupHandler : MonoBehaviour
	{
		[Inject]
		private Inventory _inventory;
		[Inject]
		private Camera _camera;
		
		[SerializeField]
		private LayerMask _pickupLayer;
		[SerializeField]
		private float _pickupRange;

		private void Update()
		{
			if (Input.GetButtonDown("Take"))
			{
				PickUp();
			}
		}

		private void PickUp()
		{
			Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

			if (Physics.Raycast(ray,
					out var hit,
					_pickupRange,
					_pickupLayer))
			{
				if (hit.transform.TryGetComponent(out Pickup pickup))
				{
					_inventory.AddItem(pickup._item);
					Destroy(hit.transform.gameObject);
				}
			}
		}
	}
}