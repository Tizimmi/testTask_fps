using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Pickup : MonoBehaviour
	{
		[SerializeField]
		public Rigidbody _rb;
		[SerializeField]
		public Collider _collider;
		[SerializeField]
		public Vector3 _positionInHand;
		
		[SerializeField]
		public Item _item;
		
		public virtual void Enable()
		{
			_rb.isKinematic = true;
			_collider.isTrigger = true;
			
			var trans = transform;
			trans.localPosition = _positionInHand;
			trans.localRotation = Quaternion.identity;
		}
	}
}