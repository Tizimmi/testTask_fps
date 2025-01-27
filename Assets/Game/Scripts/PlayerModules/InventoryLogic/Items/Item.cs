using UnityEngine;

namespace Game.Scripts.PlayerModules.InventoryLogic.Items
{
	[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Inventory) + "/" + nameof(Item), fileName = "new_" + nameof(Item))]
	public class Item : ScriptableObject
	{
		[SerializeField]
		public string _name;
		[SerializeField]
		public ItemType _type;
		[SerializeField]
		public GameObject _prefab;
	}
}