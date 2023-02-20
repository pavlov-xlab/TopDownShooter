using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class GameController : MonoBehaviour
	{
		public static GameController instance { get; private set; }

		private void Awake()
		{
			if (instance != null)
			{
				Debug.LogWarning("instance not null");
				Destroy(gameObject);
			}

			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
