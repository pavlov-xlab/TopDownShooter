using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class UICharacterUpgrade : UIBasePanel
	{
		public void Back()
		{
			UICore.current.Swap("MainMenu");
		}

		public void OnPlayClick()
		{
			UICore.current.LoadLevel();
		}
	}
}
