using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[CreateAssetMenu(menuName = "TopDownShooter/WeaponsDescription", fileName = "WeaponsDescription")]
	public class WeaponsDescription : ScriptableObject
	{
		[System.Serializable]
		public class WeaponDesc
		{
			public string id;
			public GameObject prefab;
		}

		[SerializeField] private List<WeaponDesc> m_weaponsDesc = new();

		public WeaponDesc GetWeaponDesc(string id)
		{
			return m_weaponsDesc.Find(x => x.id == id);
		}

	}
}