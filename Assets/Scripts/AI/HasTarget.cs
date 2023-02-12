using TheKiwiCoder;

namespace TopDownShooter.AI
{
	public class HasTarget : DecoratorNode
	{
		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			if (!blackboard.target)
			{
				return State.Failure;
			}
			return child.Update();
		}
	}
}