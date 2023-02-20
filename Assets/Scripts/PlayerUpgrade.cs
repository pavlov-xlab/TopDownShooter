using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class PlayerUpgrade
	{
		public static CharacterData Upgrade(int level, CharacterData data)
		{
			data = data.Clone();
			data.health += level * 10;
			data.speedMove += level * 0.2f;
			return data;
		}

		public static SkillData UpgradeSkill(int level, SkillData data)
		{
			return data;
		}

	}
}
