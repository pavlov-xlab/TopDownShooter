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
		private bool m_isAttack = false;
		private float m_nextShootTime;

		public float attackDistance => m_attackDistance;

		private Transform m_target;

		public UnityEvent<Transform> onAttack;

		protected void Attack()
		{
			onAttack.Invoke(m_target);
		}

		public void StartAttack(Transform target)
		{
			m_target = target;
			m_isAttack = true;
			m_nextShootTime = Time.time;
		}

		public void StopAttack()
		{
			m_isAttack = false;
		}

		private void Update()
		{
			if (m_isAttack)
			{
				if (Time.time >= m_nextShootTime)
				{
					Attack();
					m_nextShootTime = Time.time + m_cooldownTime;
				}
			}
		}

		public void SetActive(bool state)
		{
			gameObject.SetActive(state);
		}
	}
}