using TheKiwiCoder;
using UnityEngine;

namespace TopDownShooter
{
	public class IsReadyAttack : DecoratorNode
	{
		protected override void OnStart()
		{

		}

		protected override void OnStop()
		{

		}

		protected override State OnUpdate()
		{
			var sqrMagnitude = Vector3.SqrMagnitude(blackboard.target.position - context.transform.position);
			var attackDistance = context.attackManager.attackDistance;
			if (sqrMagnitude > attackDistance * attackDistance)
			{
				return State.Failure;
			}

			return child.Update();
		}
	}
}
