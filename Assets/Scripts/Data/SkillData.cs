using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[CreateAssetMenu(menuName = "TopDownShooter/SkillData", fileName = "SkillData")]
	public class SkillData : ScriptableObject
	{
		public AttackComponent prefab;
		public float mana;
		public float attackDistance;
		public float cooldownTime;
		public float damage;
		public float flightDistance;
		public float flightSpeed;
	}
}
