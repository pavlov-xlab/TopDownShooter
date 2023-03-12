using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TopDownShooter
{

	public class MoveObject : MonoBehaviour
	{
		[SerializeField] private float m_timeTotal = 10f;
		private void Start()
		{
			transform.DOLocalMove(transform.localPosition + Vector3.right * 5f, m_timeTotal).SetLoops(-1, LoopType.Yoyo);
		}
	}
}