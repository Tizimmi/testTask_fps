using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.PlayerModules.HealthModule
{
	public class HealthComponent : MonoBehaviour
	{
		public int _maxHealth;
		
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
			
			Debug.Log($"{_currentHealth}");
			
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
			_currentHealth = Mathf.Min(_maxHealth, _currentHealth + value);
			Debug.Log($"Healed for {value}");
		}
	}
}