using Game.Scripts.PlayerModules;
using Game.Scripts.PlayerModules.InventoryLogic;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Global
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField]
		private PlayerController _player;

		public override void InstallBindings()
		{
			Container.BindInstance(_player).AsSingle();
			Container.Bind<Inventory>().FromResolveGetter<PlayerController>(x => x.Inventory).AsSingle();
			Container.Bind<PickupHandler>().FromResolveGetter<PlayerController>(x => x.GetComponent<PickupHandler>());
		}
	}
}