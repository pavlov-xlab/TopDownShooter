using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class ManaComponent : MonoBehaviour
	{
		[SerializeField] private float m_current = 100f;
		[SerializeField] private float m_maxValue = 100f;
		[SerializeField] private float m_speedAllRestore = 2f;

		public float current => m_current;

		public float percent => m_current / m_maxValue;

		public void Init(float maxValue, float speedRestore)
		{
			m_current = m_maxValue = maxValue;
			m_speedAllRestore = speedRestore;
		}

		public void Reduce(float value)
		{
			m_current -= value;
		}

		private void Update()
		{
			var offset = (m_maxValue / m_speedAllRestore) * Time.deltaTime;
			m_current = Mathf.Clamp(m_current + offset, 0, m_maxValue);
		}

	}
}
