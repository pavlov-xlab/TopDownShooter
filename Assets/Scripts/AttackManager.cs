using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class AttackManager : MonoBehaviour
	{
		private List<AttackComponent> m_skills = new();

		private AttackComponent m_currentSkill;

		public float attackDistance => m_currentSkill.attackDistance;

		private void Awake()
		{
			GetComponentsInChildren(true, m_skills);

			m_skills.ForEach(x => x.SetActive(false));
		}

		private void Start()
		{
			SelectSkill(0);
		}

		public void NextSkill()
		{
			var index = m_skills.IndexOf(m_currentSkill) + 1;
			if (index >= m_skills.Count)
			{
				index = 0;
			}
			SelectSkill(index);
		}

		public void SelectSkill(int index)
		{
			if (index >= 0 && index < m_skills.Count)
			{
				if (m_currentSkill != null)
				{
					m_currentSkill.SetActive(false);
				}

				m_currentSkill = m_skills[index];
				m_currentSkill.SetActive(true);
			}
		}

		public void StartAttack()
		{
			m_currentSkill.StartAttack(null);
		}

		public void StopAttack()
		{
			m_currentSkill.StopAttack();
		}
	}
}