using Game.Scripts.EnemyLogic;
using System;
using UnityEngine;

namespace Game.Scripts.PlayerModules.HealthModule
{
	public class HealthComponent : MonoBehaviour, IDamagable
	{
		public event Action OnDeath;
		public event Action<int, int> OnHealthChange;

		[SerializeField]
		private int _maxHealth;

		private int _currentHealth;

		private void Start()
		{
			Init();
		}

		public void TakeDamage(int value)
		{
			_currentHealth = Mathf.Max(0, _currentHealth - value);

			OnHealthChange?.Invoke(_currentHealth, _maxHealth);

			if (_currentHealth == 0)
				Death();
		}

		public bool TryHeal(int value)
		{
			if (_currentHealth == _maxHealth)
				return false;

			Heal(value);
			return true;
		}

		private void Init()
		{
			_currentHealth = _maxHealth;
		}

		private void Death()
		{
			Destroy(gameObject);
			OnDeath?.Invoke();
		}

		private void Heal(int value)
		{
			_currentHealth = Mathf.Min(_maxHealth, _currentHealth + value);

			OnHealthChange?.Invoke(_currentHealth, _maxHealth);
		}
	}
}