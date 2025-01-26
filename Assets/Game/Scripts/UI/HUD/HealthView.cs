using Game.Scripts.PlayerModules.HealthModule;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.HUD
{
	public class HealthView : MonoBehaviour
	{
		[SerializeField]
		private HealthComponent _health;
		[SerializeField]
		private Image _healthBar;

		private void UpdateHealth(int currentHealth)
		{
			_healthBar.fillAmount = Mathf.Clamp(((float) currentHealth / _health.MaxHealth), 0, 1);
		}

		private void OnEnable()
		{
			_health.OnHealthChange += UpdateHealth;
		}

		private void OnDisable()
		{
			_health.OnHealthChange -= UpdateHealth;
		}
	}
}