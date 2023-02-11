using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class HealthComponent : MonoBehaviour
	{
		[SerializeField] private float m_health = 100;

		public void TakeDamage(float damage)
		{
			m_health = Mathf.Max(m_health - damage, 0f);

			if (m_health == 0)
			{
				Destroy(gameObject);
			}
		}
	}
}