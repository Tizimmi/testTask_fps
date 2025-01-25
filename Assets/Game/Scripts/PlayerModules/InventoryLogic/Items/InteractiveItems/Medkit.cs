using Game.Scripts.PlayerModules.HealthModule;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Medkit : Consumable
	{
		[Inject]
		private readonly HealthComponent _playerHealth;

		[SerializeField]
		private int _healValue;
		
		public override void Use()
		{
			_playerHealth.Heal(_healValue);
			Destroy(gameObject);
		}
	}

	public abstract class Consumable : MonoBehaviour
	{
		public abstract void Use();
	}
}