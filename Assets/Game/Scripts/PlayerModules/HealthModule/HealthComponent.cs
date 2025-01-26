using System;
using UnityEngine;

namespace Game.Scripts.PlayerModules.HealthModule
{
	public class HealthComponent : MonoBehaviour
	{
		public event Action<int> OnHealthChange;
		
		[field: SerializeField]
		public int MaxHealth { get; private set; }
		
		private int _currentHealth;

		private void Start()
		{
			Init();
		}

		private void Init()
		{
			_currentHealth = MaxHealth;
		}
		
		public void TakeDamage(int value)
		{
			_currentHealth = Mathf.Max(0, _currentHealth - value);
			
			OnHealthChange?.Invoke(_currentHealth);
			
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

		public void Heal(int value)
		{
			_currentHealth = Mathf.Min(MaxHealth, _currentHealth + value);
			
			OnHealthChange?.Invoke(_currentHealth);
		}
	}
}