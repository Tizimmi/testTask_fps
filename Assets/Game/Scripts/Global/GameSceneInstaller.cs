using Game.Scripts.PlayerModules;
using Game.Scripts.PlayerModules.HealthModule;
using Game.Scripts.PlayerModules.InventoryLogic;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Global
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField]
		private Player _player;

		public override void InstallBindings()
		{
			Container.BindInstance(_player).AsSingle();
			Container.Bind<Inventory>().FromResolveGetter<Player>(x => x.Inventory).AsSingle();
			Container.Bind<PickupHandler>().FromResolveGetter<Player>(x => x.GetComponent<PickupHandler>());
			Container.Bind<HealthComponent>().FromResolveGetter<Player>(x => x.GetComponent<HealthComponent>());
		}
	}
}