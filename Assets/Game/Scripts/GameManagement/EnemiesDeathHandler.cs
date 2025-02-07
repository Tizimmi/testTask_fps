﻿using Game.Scripts.PlayerModules.HealthModule;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.GameManagement
{
	public class EnemiesDeathHandler
	{
		private readonly List<HealthComponent> _enemies = new();
		private readonly GameLoopManager _gameLoopManager;

		private readonly Transform _root;

		private EnemiesDeathHandler(GameLoopManager gameLoopManager, EnemyRootProvider enemyRootProvider)
		{
			_gameLoopManager = gameLoopManager;
			_root = enemyRootProvider._root;

			foreach (var enemy in _root.GetComponentsInChildren<HealthComponent>())
				_enemies.Add(enemy);

			foreach (var health in _enemies)
				health.OnDeath += CheckEnemiesDead;
		}

		private void CheckEnemiesDead()
		{
			if (_root.childCount <= 1)
				_gameLoopManager.GameWin();
		}
	}
}