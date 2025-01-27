using Game.Scripts.GameManagement;
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
		[SerializeField]
		private GameLoopManager _gameLoopManager;
		[SerializeField]
		private EnemyRootProvider _enemyRootProvider;
		[SerializeField]
		private HitMarkerController _hitMarkerController;

		public override void InstallBindings()
		{
			Container.Bind<Inventory>().FromResolveGetter<Player>(x => x.Inventory).AsSingle();
			Container.Bind<PickupHandler>().FromResolveGetter<Player>(x => x.GetComponent<PickupHandler>()).AsSingle();
			Container.Bind<HealthComponent>().FromResolveGetter<Player>(x => x.GetComponent<HealthComponent>()).AsSingle();
			Container.Bind<Shooting>().FromResolveGetter<Player>(x => x.GetComponent<Shooting>()).AsSingle();
			Container.Bind<Camera>().FromResolveGetter<Player>(x => x.GetComponentInChildren<Camera>()).AsSingle();

			Container.Bind<PlayerDeathHandler>().AsSingle().NonLazy();
			Container.Bind<EnemiesDeathHandler>().AsSingle().NonLazy();
			Container.Bind<GamePrefabFactory>().AsSingle();

			Container.BindInstance(_player).AsSingle();
			Container.BindInstance(_gameLoopManager).AsSingle();
			Container.BindInstance(_enemyRootProvider).AsSingle();
			Container.BindInstance(_ammoView).AsSingle();
			Container.BindInstance(_hitMarkerController).AsSingle();
		}
	}
}