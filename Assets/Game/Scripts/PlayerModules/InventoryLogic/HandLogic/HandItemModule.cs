using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;
using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.HandLogic
{
	public class HandItemModule : MonoBehaviour
	{
		[field: SerializeField]
		public InventoryItem CurrentActiveItem { get; private set; }

		[Inject]
		private readonly Inventory _inventory;

		private void Update()
		{
			if(!CurrentActiveItem)
				return;
			
			if (Input.GetButtonDown("Drop"))
			{
				CurrentActiveItem.GetComponent<Pickup>().Drop();
				_inventory.RemoveItem(CurrentActiveItem);
				CurrentActiveItem = null;
			}
			
			if (Input.GetButtonDown("Fire1") && CurrentActiveItem.GetComponent<Gun>())
			{
				CurrentActiveItem.GetComponent<Gun>().Shoot();
			}

			if (Input.GetButtonDown("Fire2"))
			{
				
			}
		}

		public void SetActiveItem(InventoryItem item)
		{
			if (CurrentActiveItem)
				CurrentActiveItem.UnEquip();
			
			CurrentActiveItem = item;
		}
	}
}