namespace TopDownShooter.States
{
	public class MainMenuGameMode : GameModeBehavior
	{
		public void GotoSelectLevel()
		{
			ChangeState<SelectLevelState>();
		}
		
		public void GotoUpgrade()
		{
			ChangeState<CharacterUpgradeState>();
		}

		public void LoadLevel()
		{
			GameController.LoadScene("Level_1");
		}
	}
}