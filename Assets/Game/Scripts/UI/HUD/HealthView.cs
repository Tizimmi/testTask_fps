using Game.Scripts.PlayerModules.HealthModule;
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

		private void OnEnable()
		{
			_health.OnHealthChange += UpdateHealth;
		}

		private void OnDisable()
		{
			_health.OnHealthChange -= UpdateHealth;
		}

		private void UpdateHealth(int currentHealth, int maxHealth)
		{
			_healthBar.fillAmount = Mathf.Clamp(((float) currentHealth / maxHealth), 0, 1);
		}
	}
}