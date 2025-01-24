using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	public class HandItemModule : MonoBehaviour
	{
		[SerializeField]
		private KeyCode _dropButton;
		[SerializeField]
		private KeyCode _pickupButton;

		[Inject]
		private Inventory _inventory;
		
		private InventoryItem _currentActiveItem;

		private void Update()
		{
			if(_currentActiveItem == null)
				return;

			if (Input.GetKeyDown(_dropButton))
			{
				_inventory.RemoveItem(_currentActiveItem);
				_currentActiveItem = null;
				return;
			}

			if (_currentActiveItem is Gun weapon)
			{
				weapon.Zoom(Input.GetKey(weapon._zoomButton));
			}

			if (Input.GetKeyDown(_currentActiveItem.UseButton))
			{
				_currentActiveItem.Use();
			}
		}

		public void SetActiveItem(InventoryItem item)
		{
			_currentActiveItem = item;
		}
	}
}