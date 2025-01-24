using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Pistol : Gun
	{
		public override void Use()
		{
			
		}

		public override void Equip(Transform root)
		{
			base.Equip(root);
		}

		public override void Zoom(bool isZooming)
		{
			base.Zoom(isZooming);
		}
	}
}