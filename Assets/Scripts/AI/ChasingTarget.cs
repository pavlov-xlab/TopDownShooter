using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TopDownShooter.AI
{
	[System.Serializable]
	public class ChasingTarget : ActionNode
	{
		public float stoppingDistance = 2;

		protected override void OnStart()
		{
			context.agent.stoppingDistance = stoppingDistance;
			context.agent.SetDestination(blackboard.target.transform.position);
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			var target = blackboard.target;
			if (target)
			{
				var agent = context.agent;
				if (Time.frameCount % 3 == 0)
				{
					agent.SetDestination(target.transform.position);
				}

				if (agent.pathPending)
				{
					return State.Running;
				}

				if (agent.remainingDistance < agent.stoppingDistance)
				{
					return State.Success;
				}

				if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
				{
					return State.Failure;
				}

				return State.Running;
			}

			return State.Failure;
		}
	}
}
