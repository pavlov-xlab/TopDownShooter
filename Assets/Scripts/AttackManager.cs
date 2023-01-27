using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class AttackManager : MonoBehaviour
	{
		private List<IWeapon> m_weapons = new();

		private IWeapon m_mainAttack;

		private void Awake()
		{
			GetComponentsInChildren(true, m_weapons);

			m_weapons.ForEach(x => x.SetActive(false));
		}

		private void Start()
		{
			SelectWeapon(0);
		}

		public void NextWeapon()
		{
			var index = m_weapons.IndexOf(m_mainAttack) + 1;
			if (index >= m_weapons.Count)
			{
				index = 0;
			}
			SelectWeapon(index);
		}

		public void SelectWeapon(int index)
		{
			if (index >= 0 && index < m_weapons.Count)
			{
				if (m_mainAttack != null)
				{
					m_mainAttack.SetActive(false);
				}

				m_mainAttack = m_weapons[index];
				m_mainAttack.SetActive(true);
			}
		}

		public void StartAttack()
		{
			m_mainAttack.StartAttack();
		}

		public void StopAttack()
		{
			m_mainAttack.StopAttack();
		}
	}
}