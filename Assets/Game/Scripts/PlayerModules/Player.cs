using Game.Scripts.PlayerModules.InventoryLogic;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using UnityEngine;

namespace Game.Scripts.PlayerModules
{
	public class Player : MonoBehaviour
	{
		[SerializeField]
		private PickupHandler _pickupHandler;

		public Inventory Inventory = new();
	}
}