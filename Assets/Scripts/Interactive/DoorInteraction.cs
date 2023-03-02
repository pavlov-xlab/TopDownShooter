using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TopDownShooter
{
	public class DoorInteraction : MonoBehaviour
	{
		[SerializeField] private UnityEvent onOpen;
		[SerializeField] private UnityEvent onClose;

		private bool m_isOpen = false;
		
		public void Open()
		{
			if (!m_isOpen)
			{
				m_isOpen = true;
				onOpen.Invoke();
			}
		}
		
		public void Close()
		{
			if (m_isOpen)
			{
				m_isOpen = false;
				onClose.Invoke();
			}
		}
	}
}