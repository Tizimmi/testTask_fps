namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class ConsumablePickup : Pickup
	{
		protected bool _canBeUsed;

		public override void Enable()
		{
			base.Enable();
			_canBeUsed = true;
		}

		public virtual void Use() { }
	}
}