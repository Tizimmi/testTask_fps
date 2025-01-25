using Game.Scripts.PlayerModules.InventoryLogic;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using UnityEngine;

namespace Game.Scripts.PlayerModules
{
	public class Player : MonoBehaviour
	{
		[SerializeField]
		private PickupHandler _pickupHandler;
		[SerializeField]
		private HandItemModule _handItemModule;
		
		public Inventory Inventory = new();
		
	}
}