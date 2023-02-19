using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
	public class AttackComponent : MonoBehaviour
	{
		[SerializeField] private float m_cooldownTime = 0.1f;
		[SerializeField] private float m_attackDistance = 5f;
		[SerializeField] private float m_mana = 5f;
		[SerializeField] private float m_damage = 50f;
		private IDamagerComponent m_damager;

		public bool canAttack => m_timer <= 0f;
		public float mana => m_mana;
		public float cooldownTime => m_cooldownTime;
		public float attackDistance => m_attackDistance;

		private float m_timer = 0;

		private void Awake()
		{
			m_damager = GetComponent<IDamagerComponent>();
			m_timer = 0;
		}

		public void Init(float mana, float cooldownTime, float attackDistance, float damage, float flyingSpeed, float flyingDistance)
		{
			m_mana = mana;
			m_cooldownTime = cooldownTime;
			m_attackDistance = attackDistance;
			m_damage = damage;

			if (m_damager is IFlyingInitialization flying)
			{
				flying.InitFlying(flyingSpeed, flyingDistance);
			}
		}

		public void Attack(Transform target)
		{
			m_damager.Attack(target, m_damage);
			m_timer = m_cooldownTime;
		}

		private void Update()
		{
			if (m_timer > 0f)
			{
				m_timer -= Time.deltaTime;
			}
		}

		public void SetActive(bool state)
		{
			gameObject.SetActive(state);
		}
	}
}