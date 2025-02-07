﻿using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
	public class FaceCamera : MonoBehaviour
	{
		[Inject]
		private Camera _camera;

		void Update()
		{
			if (_camera == null)
				return;

			var direction = _camera.transform.position - transform.position;

			if (direction != Vector3.zero)
			{
				var rotation = Quaternion.LookRotation(direction);
				transform.rotation = rotation * Quaternion.Euler(0, 180, 0);
			}
		}
	}
}