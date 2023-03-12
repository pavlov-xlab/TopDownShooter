using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
	public class UICore : MonoBehaviour
	{
		private void Awake()
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(false);
			}
		}
	}
}
