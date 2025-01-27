using UnityEngine;
using Zenject;

namespace Game.Scripts.Global
{
    public class GamePrefabFactory
	{
		private readonly DiContainer _container;

		public GamePrefabFactory(DiContainer container)
		{
			_container = container;
		}

		public GameObject InstantiatePrefab(
			Object prefab,
			Vector3 position,
			Quaternion rotation,
			Transform parentTransform)
		{
			return _container.InstantiatePrefab(prefab,
				position,
				rotation,
				parentTransform);
		}

		public T InstantiatePrefab<T>(
			Object prefab,
			Vector3 position,
			Quaternion rotation,
			Transform parentTransform)
			where T : Component
		{
			return InstantiatePrefab(prefab,
					position,
					rotation,
					parentTransform)
				.GetComponent<T>();
		}

		public GameObject InstantiatePrefab(Object prefab, Transform parentTransform)
		{
			return _container.InstantiatePrefab(prefab, parentTransform);
		}

		public T InstantiatePrefab<T>(Object prefab, Transform parentTransform)
			where T : Component
		{
			return InstantiatePrefab(prefab, parentTransform).GetComponent<T>();
		}
	}
}