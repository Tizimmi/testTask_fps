using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.HUD
{
	public class GameOverScreenView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _gameOverText;

		public void Reset()
		{
			_gameOverText.text = string.Empty;
		}

		public void SetGameLose()
		{
			_gameOverText.text = "YOU DIED";
		}

		public void SetGameWin()
		{
			_gameOverText.text = "YOU WON";
		}
	}
}