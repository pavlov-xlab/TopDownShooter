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

		public bool canAttack => m_timer <= 0f;
		public float mana => m_mana;
		public float cooldownTime => m_cooldownTime;
		public float attackDistance => m_attackDistance;
		public UnityEvent<Transform> onAttack;

		private float m_timer = 0;

		public void Attack(Transform target)
		{
			onAttack.Invoke(target);
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