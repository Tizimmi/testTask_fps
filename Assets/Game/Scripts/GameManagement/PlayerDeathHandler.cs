using Game.Scripts.PlayerModules.HealthModule;

namespace Game.Scripts.GameManagement
{
	public class PlayerDeathHandler
	{
		private readonly GameLoopManager _gameLoopManager;

		public PlayerDeathHandler(HealthComponent playerHealth, GameLoopManager gameLoopManager)
		{
			_gameLoopManager = gameLoopManager;
			playerHealth.OnDeath += HandleDeath;
		}

		private void HandleDeath()
		{
			_gameLoopManager.GameLose();
		}
	}
}