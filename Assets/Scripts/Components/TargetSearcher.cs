using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class TargetSearcher : MonoBehaviour
	{
		[SerializeField] private string m_targetTag;

		public event System.Action<GameObject> onTargetFind;
		public event System.Action<GameObject> onTargetLost;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(m_targetTag))
			{
				onTargetFind?.Invoke(other.gameObject);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(m_targetTag))
			{
				onTargetLost?.Invoke(other.gameObject);
			}
		}
	}
}