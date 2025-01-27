using System;
using UnityEngine;

namespace Game.Scripts.PlayerModules.HealthModule
{
	public class HealthComponent : MonoBehaviour
	{
		public event Action<int> OnHealthChange;
		
		[field: SerializeField]
		public int MaxHealth { get; private set; }
		
		public int CurrentHealth { get; private set; }

		private void Start()
		{
			Init();
		}

		private void Init()
		{
			CurrentHealth = MaxHealth;
		}
		
		public void TakeDamage(int value)
		{
			CurrentHealth = Mathf.Max(0, CurrentHealth - value);
			
			OnHealthChange?.Invoke(CurrentHealth);
			
			if (CurrentHealth == 0)
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
			CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + value);
			
			OnHealthChange?.Invoke(CurrentHealth);
		}
	}
}