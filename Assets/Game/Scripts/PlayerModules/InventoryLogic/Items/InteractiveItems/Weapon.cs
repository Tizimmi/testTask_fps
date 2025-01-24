using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Inventory) + "/" + nameof(Weapon) , fileName = "new_" + nameof(Weapon))]
	public class Weapon : InventoryItem
	{
		public int _damage;
		public int _range;
		public int _magazineSize;
		
		public override void Use()
		{
			
		}
	}
}