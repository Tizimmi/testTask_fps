using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Pickup : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rb;
		[SerializeField]
		private Collider _collider;
		[SerializeField]
		private Vector3 _positionInHand;
		
		[SerializeField]
		public Item _item;
		
		public void Enable()
		{
			_rb.isKinematic = true;
			_collider.isTrigger = true;
			
			var trans = transform;
			trans.localPosition = _positionInHand;
			trans.localRotation = Quaternion.identity;
		}
	}
}