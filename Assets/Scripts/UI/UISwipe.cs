using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace TopDownShooter
{
	public class UISwipe : MonoBehaviour, IDropHandler, IDragHandler
	{
		public UnityEvent onLeftSwipe;
		public UnityEvent onRightSwipe;

		public void OnDrag(PointerEventData eventData)
		{
			
		}

		public void OnDrop(PointerEventData eventData)
		{
			var dif = eventData.position - eventData.pressPosition;
			
			if (dif.x > 0)
			{
				Debug.Log("Left");
				onRightSwipe.Invoke();
			}
			else
			{
				Debug.Log("Right");
				onLeftSwipe.Invoke();
			}
		}
	}
}
