using Game.Scripts.PlayerModules;
using Game.Scripts.PlayerModules.HealthModule;
using Game.Scripts.PlayerModules.InventoryLogic;
using Game.Scripts.PlayerModules.InventoryLogic.EquipmentLogic;
using Game.Scripts.PlayerModules.InventoryLogic.HandLogic;
using Game.Scripts.UI.HUD;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Global
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField]
		private Player _player;
		[SerializeField]
		private AmmoView _ammoView;

		public override void InstallBindings()
		{
			Container.BindInstance(_player).AsSingle();
			Container.Bind<Inventory>().FromResolveGetter<Player>(x => x.Inventory).AsSingle();
			Container.Bind<PickupHandler>().FromResolveGetter<Player>(x => x.GetComponent<PickupHandler>()).AsSingle();
			Container.Bind<HealthComponent>().FromResolveGetter<Player>(x => x.GetComponent<HealthComponent>()).AsSingle();
			Container.Bind<Shooting>().FromResolveGetter<Player>(x => x.GetComponent<Shooting>()).AsSingle();
			Container.Bind<Camera>().FromResolveGetter<Player>(x => x.GetComponentInChildren<Camera>()).AsSingle();

			Container.Bind<GamePrefabFactory>().AsSingle();

			Container.BindInstance(_ammoView).AsSingle();
		}
	}
}