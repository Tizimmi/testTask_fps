using Game.Scripts.PlayerModules.HealthModule;
using Game.Scripts.PlayerModules.InventoryLogic;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using UnityEngine;

namespace Game.Scripts.PlayerModules
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private EquipmentModule _equipmentModule;
		[SerializeField]
		private HandItemModule _handItemModule;
		[SerializeField]
		private Zoom _zoomController;
		
		public HealthComponent HealthComponent;
		public Inventory Inventory = new();
	}
}