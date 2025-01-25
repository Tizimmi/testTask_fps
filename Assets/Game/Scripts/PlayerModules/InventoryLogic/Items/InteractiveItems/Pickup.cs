using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems
{
	public class Pickup : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rb;
		[SerializeField]
		private Collider _collider;
		
		public virtual void Take(Transform root)
		{
			_rb.isKinematic = true;
			_collider.isTrigger = true;
			gameObject.SetActive(false);
			gameObject.transform.SetParent(root);
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
		
		public void Drop()
		{
			transform.gameObject.SetActive(true);
			_collider.isTrigger = false;
			_rb.isKinematic = false;
			gameObject.transform.SetParent(null);
		}
	}
}