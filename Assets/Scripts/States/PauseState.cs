using UnityEngine;

namespace TopDownShooter.States
{
	public class PauseState : GameStateBehavior
	{
		private void OnEnable()
		{
			Time.timeScale = 0f;
		}

		private void OnDisable()
		{
			Time.timeScale = 1f;
		}
	}
}