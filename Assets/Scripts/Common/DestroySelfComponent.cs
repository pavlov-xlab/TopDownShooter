using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class DestroySelfComponent : MonoBehaviour
	{
		public void DestroySelf()
		{
			Destroy(gameObject);
		}
	}
}
