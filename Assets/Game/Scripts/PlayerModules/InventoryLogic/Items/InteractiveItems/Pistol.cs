using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Pistol : Weapon
	{
		public override void Use()
		{
			Debug.Log($"Shoot from pistol, deal {_damage} damage");
		}
	}
}