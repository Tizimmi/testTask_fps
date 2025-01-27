using System;
using UnityEngine;

namespace Game.Scripts.PlayerModules.HealthModule
{
	public class HealthComponent : MonoBehaviour
	{
		public event Action<int, int> OnHealthChange;

		[SerializeField]
		private int _maxHealth;

		private int _currentHealth;

		private void Start()
		{
			Init();
		}

		private void Init()
		{
			_currentHealth = _maxHealth;
		}
		
		public void TakeDamage(int value)
		{
			_currentHealth = Mathf.Max(0, _currentHealth - value);
			
			OnHealthChange?.Invoke(_currentHealth, _maxHealth);
			
			if (_currentHealth == 0)
			{
				Death();
			}
		}

		private void Death()
		{
			Debug.Log("I am dead");
			Destroy(gameObject);
		}

		public bool TryHeal(int value)
		{
			if (_currentHealth == _maxHealth)
				return false;
			Heal(value);
			return true;
		}

		private void Heal(int value)
		{
			_currentHealth = Mathf.Min(_maxHealth, _currentHealth + value);
			
			OnHealthChange?.Invoke(_currentHealth, _maxHealth);
		}
	}
}