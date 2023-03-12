using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class LifeTimeDelay : MonoBehaviour
	{
		[SerializeField] private float m_delay = 1f;
		private float m_startTime;

		private void Start()
		{
			m_startTime = Time.time;
		}

		private void Update()
		{
			if (Time.time > m_startTime + m_delay)
			{
				Destroy(gameObject);
			}
		}
	}
}