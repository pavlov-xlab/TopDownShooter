using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class FireballDamager : MonoBehaviour
	{
		[SerializeField] private BulletComponent m_bulletPrefab;

		public void Shoot(Transform target)
		{
			var bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);
			bullet.Shoot();
		}
	}
}
