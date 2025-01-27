using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.HUD
{
	public class HitMarker : MonoBehaviour
	{
		[SerializeField]
		private float _lifeTime;
		[SerializeField]
		private Image _image;
		
		private void Update()
		{
			_lifeTime -= Time.deltaTime;

			_image.color = new Color(_image.color.r,
				_image.color.g,
				_image.color.b,
				Mathf.Clamp(_lifeTime, 0, 255));
			
			if(_lifeTime <= 0)
				Destroy(gameObject);
		}
	}
}