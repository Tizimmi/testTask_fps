using UnityEngine;

namespace Game.Scripts.UI.HUD
{
	public class HitMarkerController : MonoBehaviour
	{
		[SerializeField]
		private HitMarker _prefab;
		[SerializeField]
		private Transform _root;

		public void ShowHitMarker()
		{
			Instantiate(_prefab, _root);
		}
	}
}