using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public interface IWeapon
	{
		void SetActive(bool state);

		void StartAttack();

		void StopAttack();
	}


	public class AttackComponent : MonoBehaviour, IWeapon
	{
		[SerializeField] private BulletComponent m_bulletPrefab;
		[SerializeField] private float m_shootDelay = 0.1f;
		private bool m_isAttack = false;
		private float m_nextShootTime;

		private void Attack()
		{
			var bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);
			bullet.Shoot();
		}

		public void StartAttack()
		{
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
					m_nextShootTime = Time.time + m_shootDelay;
				}
			}
		}

		public void SetActive(bool state)
		{
			gameObject.SetActive(state);
		}
	}
}