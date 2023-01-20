using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TopDownShooter
{

	public class MoveObject : MonoBehaviour
	{
		private Vector3 m_startPoint;
		private Vector3 m_endPoint;
		[SerializeField] private float m_timeTotal = 10f;
		private float m_timer = 0f;

		private void Awake()
		{
			m_startPoint = transform.position + Vector3.left * 2;
			m_endPoint = transform.position + Vector3.right * 2;
		}

		private void Update()
		{
			m_timer += Time.deltaTime;
			if (m_timer > m_timeTotal)
			{
				m_timer -= m_timeTotal;
				(m_startPoint, m_endPoint) = (m_endPoint, m_startPoint);
			}
			float tr = m_timer / m_timeTotal;
			Vector3 pos = Vector3.Lerp(m_startPoint, m_endPoint, tr);
			transform.position = pos;
			// transform.DOLocalMove(transform.localPosition + Vector3.right * 5f, 3f).SetLoops(-1, LoopType.Yoyo);
		}
	}
}