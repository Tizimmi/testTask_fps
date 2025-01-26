using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.HUD
{
	public class AmmoView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _ammoField;

		public void ResetText()
		{
			_ammoField.text = string.Empty;
		}
		
		public void SetReloadState()
		{
			_ammoField.text = "Reloading...";
		}

		public void UpdateAmmo(int gunCurrentMagazineFill, int gunMagazineSize, int gunCurrentAmmoStorage)
		{
			_ammoField.text = $"{gunCurrentMagazineFill}/{gunMagazineSize} ({gunCurrentAmmoStorage})";
		}
	}
}