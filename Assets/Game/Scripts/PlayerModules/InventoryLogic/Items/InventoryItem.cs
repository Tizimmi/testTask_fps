using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items
{
	[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Inventory) + "/" + nameof(InventoryItem) , fileName = "new_" + nameof(InventoryItem))]

	public class InventoryItem : ScriptableObject
	{
		[SerializeField]
		public string _itemName;
		[SerializeField]
		public ItemType _itemType;
		[SerializeField]
		public GameObject _prefab;
		[field: SerializeField]
		public KeyCode UseButton { get; private set; }

		private GameObject _instance;
		public virtual void Equip(Transform root)
		{
			Debug.Log($"Equipped {_itemName}");
			_instance = Instantiate(_prefab, root);
		}
		
		public virtual void UnEquip()
		{
			if (_instance != null)
			{
				Destroy(_instance.gameObject);
			}
		}
		
		public virtual void Use()
		{
			Debug.Log($"Used {_itemName}");
		}
	}
}