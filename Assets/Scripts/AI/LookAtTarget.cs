using TheKiwiCoder;
using UnityEngine;

namespace TopDownShooter.AI
{
	public class LookAtTarget : ActionNode
	{
		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			var targetPosition = blackboard.target.position;
			targetPosition.y = context.transform.position.y;
			context.transform.LookAt(targetPosition, Vector3.up);
			return State.Success;
		}
	}
}
