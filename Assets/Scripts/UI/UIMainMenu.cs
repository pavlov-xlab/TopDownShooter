using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class UIMainMenu : UIBasePanel
	{
		public void GotoCharacterPanel()
		{
			UICore.current.Swap("CharacterUpgrade");
		}

		public void OnPlayClick()
		{
			UICore.current.LoadLevel();
		}
	}
}
