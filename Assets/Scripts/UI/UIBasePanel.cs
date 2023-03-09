using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class UIBasePanel : MonoBehaviour
	{
		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}
