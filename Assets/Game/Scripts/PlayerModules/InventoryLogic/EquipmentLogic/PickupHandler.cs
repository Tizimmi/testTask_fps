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

		[SerializeField]
		private Camera _camera;
		[SerializeField]
		private LayerMask _pickupLayer;
		[SerializeField]
		private float _pickupRange;
		
		[SerializeField]
		private Transform _itemContainer;

		public void PickUp()
		{
			Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

			if (Physics.Raycast(ray,
					out var hit,
					_pickupRange,
					_pickupLayer))
			{
				var item = hit.transform.gameObject.GetComponent<InventoryItem>();
				item.GetComponent<Pickup>().Take(_itemContainer);
				_inventory.AddItem(item);
			}
		}
	}
}