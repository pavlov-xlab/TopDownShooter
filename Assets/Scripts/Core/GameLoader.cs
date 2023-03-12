using System;
using UnityEngine;

namespace TopDownShooter
{
	public class GameLoader : MonoBehaviour
	{
		private void Start()
		{
			GameController.LoadScene("MainMenu");
		}
	}
}