using Game.Scripts.PlayerModules.InventoryLogic.Items;
using Game.Scripts.PlayerModules.InventoryLogic.Items.InteractiveItems;

namespace Editor
{
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(AmmoBox))]
	public class AmmoBoxEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			AmmoBox item = (AmmoBox)target;

			ItemType[] allowedTypes = { ItemType.Primary, ItemType.Secondary, ItemType.Grenade };

			string[] options = new string[allowedTypes.Length];
			
			for (int i = 0; i < allowedTypes.Length; i++)
			{
				options[i] = allowedTypes[i].ToString();
			}

			int currentIndex = System.Array.IndexOf(allowedTypes, item._ammoType);

			int newIndex = EditorGUILayout.Popup("Ammo Type", currentIndex, options);
			
			item._ammoType = allowedTypes[newIndex];
			item._ammoAmount = EditorGUILayout.IntField("Ammo Amount", item._ammoAmount);
			item._rb = (Rigidbody)EditorGUILayout.ObjectField("Rigidbody", item._rb, typeof(Rigidbody), true);
			item._collider = (Collider)EditorGUILayout.ObjectField("Collider", item._collider, typeof(Collider), true);
			item._positionInHand = EditorGUILayout.Vector3Field("Position In Hand", item._positionInHand);
			item._item = (Item)EditorGUILayout.ObjectField("Item", item._item, typeof(Item), true);
			
			if (GUI.changed)
			{
				EditorUtility.SetDirty(item);
			}
		}
	}
}