using UnityEngine;

namespace Game.Scripts.Audio_and_VFX
{
	public class FireSoundDeletion : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _source;

		private void Update()
		{
			if (!_source.isPlaying)
				Destroy(gameObject);
		}
	}
}