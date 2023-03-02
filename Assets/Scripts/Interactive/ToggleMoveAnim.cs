using DG.Tweening;
using UnityEngine;

namespace TopDownShooter
{
	public class ToggleMoveAnim : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;
		[SerializeField] private float m_speed = 1f;
		[SerializeField] private bool m_isOn = true;
		private Vector3 m_onPosition;
		private Vector3 m_offPosition;

		private void Awake()
		{
			if (m_isOn)
			{
				m_onPosition = transform.localPosition;
				m_offPosition = m_onPosition + offset;
			}
			else
			{
				m_offPosition = transform.localPosition;
				m_onPosition = m_offPosition + offset;
			}
		}

		public void StartOn()
		{
			if (!m_isOn)
			{
				var distance = Vector3.Distance(transform.localPosition, m_onPosition);
				Anim(m_onPosition, distance / m_speed);
				m_isOn = true;
			}
		}

		public void StartOff()
		{
			if (m_isOn)
			{
				var distance = Vector3.Distance(transform.localPosition, m_offPosition);
				Anim(m_offPosition, distance / m_speed);
				m_isOn = false;
			}
		}

		private void Anim(in Vector3 endValue, float duration)
		{
			transform.DOKill();
			transform.DOLocalMove(endValue, duration);
		}
	}
}