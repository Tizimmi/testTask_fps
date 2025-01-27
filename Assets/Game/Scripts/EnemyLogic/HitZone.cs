using Game.Scripts.PlayerModules.HealthModule;
using UnityEngine;

namespace Game.Scripts.EnemyLogic
{
	public class HitZone : MonoBehaviour, IDamagable
	{
		[SerializeField]
		private int _damageMultiplier;

		[SerializeField]
		private HealthComponent _mainHealthComponent;
		
		public void TakeDamage(int value)
		{
			_mainHealthComponent.TakeDamage(value*_damageMultiplier);
		}
	}
}