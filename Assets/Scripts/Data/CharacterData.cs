using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public enum CharValue
	{
		Health, Mana, SpeedMove,
	}

	[CreateAssetMenu(menuName = "TopDownShooter/CharacterData", fileName = "CharacterData")]
	public class CharacterData : ScriptableObject
	{
		public float health = 100f;
		public float mana = 100f;
		public float speedRestoreMana = 10f;
		public float speedMove = 100f;
		public float baseDamage = 50f;

		public Dictionary<CharValue, float> values = new();

		public Dictionary<CharValue, float> upgrade = new() {
			{CharValue.Health, 10},
			{CharValue.Mana, 5},
		};

		public SkillData[] skills;

		public CharacterData Clone()
		{
			var data = ScriptableObject.CreateInstance<CharacterData>();
			data.baseDamage = this.baseDamage;

			foreach (var item in upgrade)
			{
				values[item.Key] += item.Value;
			}
			//....
			return data;
		}
	}
}
