using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[RequireComponent(typeof(Rigidbody))]
	public class BulletComponent : MonoBehaviour
	{
		private Rigidbody m_body;
		private float m_damage = 50f;
		private float m_lifeTime = 0;

		private void Awake()
		{
			m_body = GetComponent<Rigidbody>();
		}

		public void Shoot(float damage, float force, float distance)
		{
			m_damage = damage;
			m_lifeTime = distance / force;

			m_body.AddForce(transform.forward * force, ForceMode.Impulse);
		}

		private void Update()
		{
			m_lifeTime -= Time.deltaTime;
			if (m_lifeTime <= 0f)
			{
				Destroy(gameObject);
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			var health = other.gameObject.GetComponentInParent<HealthComponent>();
			if (health)
			{
				health.TakeDamage(m_damage);
			}

			Destroy(gameObject);
		}
	}
}