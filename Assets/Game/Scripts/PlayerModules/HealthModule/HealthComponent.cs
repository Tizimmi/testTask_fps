using UnityEngine;

namespace Game.Scripts.PlayerModules.HealthModule
{
	public class HealthComponent
	{
		public int MaxHealth;
		public int CurrentHealth;

		public void TakeDamage(int value)
		{
			CurrentHealth = Mathf.Max(0, CurrentHealth - value);

			if (CurrentHealth == 0)
			{
				Death();
			}
		}

		private void Death()
		{
			Debug.Log("I am dead");
		}

		public void Heal(int value)
		{
			CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + value);
		}
	}
}