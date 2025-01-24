using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Medkit : InventoryItem
	{
		public override void Use()
		{
			Debug.Log("Heal for {");
		}
	}
}