using Game.Scripts.UI.HUD;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.GameManagement
{
	public class GameLoopManager : MonoBehaviour
	{
		[SerializeField]
		private GameOverScreenView _gameOverScreenView;
		[SerializeField]
		private Camera _deathCamera;
		[SerializeField]
		private GameObject _hud;
		
		private const string SceneName = "GameScene";

		public void GameWin()
		{
			_gameOverScreenView.SetGameWin();
			_hud.SetActive(false);
			StartCoroutine(AwaitBeforeLoadScene());
		}

		public void GameLose()
		{
			_gameOverScreenView.SetGameLose();
			_deathCamera.gameObject.SetActive(true);
			_hud.SetActive(false);
			StartCoroutine(AwaitBeforeLoadScene());
		}

		private IEnumerator AwaitBeforeLoadScene()
		{
			yield return new WaitForSeconds(5);
			StartAgain();
		}

		private void StartAgain()
		{
			SceneManager.LoadScene(SceneName);
		}
	}
}