using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
	public class HealthComponent : MonoBehaviour
	{
		[SerializeField] private float m_health = 100;
		[SerializeField] private float m_healthMax = 100;

		public float hp => m_health;

		public bool isDead => m_health <= 0;

		public float percent => m_health / m_healthMax;

		public UnityEvent onDead;

		public void Init(float healthMax)
		{
			m_health = m_healthMax = healthMax;
		}

		public void TakeDamage(float damage)
		{
			m_health = Mathf.Max(m_health - damage, 0f);

			if (m_health == 0)
			{
				onDead.Invoke();
				// Destroy(gameObject);
			}
		}
	}
}