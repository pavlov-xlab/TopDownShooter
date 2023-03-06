using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class FireballDamager : MonoBehaviour, IDamagerComponent, IFlyingInitialization
	{
		[SerializeField] private BulletComponent m_bulletPrefab;
		[SerializeField] private float m_speed = 15f;
		[SerializeField] private float m_flightDistance = 20f;


		public void Attack(Transform target, float damage, float delay)
		{
			StartCoroutine(AttackDelay(damage, delay));
		}

		public void InitFlying(float flyingSpeed, float flyingDistance)
		{
			m_speed = flyingSpeed;
			m_flightDistance = flyingDistance;
		}

		private IEnumerator AttackDelay(float damage, float delay)
		{
			yield return new WaitForSeconds(delay);

			var bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);
			bullet.Shoot(damage, m_speed, m_flightDistance);
		}
	}
}
