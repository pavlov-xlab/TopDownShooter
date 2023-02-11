using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveToPosition : ActionNode
{
	public float stoppingDistance = 0.1f;

	protected override void OnStart()
	{
		context.agent.stoppingDistance = stoppingDistance;
		context.agent.destination = blackboard.moveToPosition;
	}

	protected override void OnStop()
	{
	}

	protected override State OnUpdate()
	{
		if (context.agent.pathPending)
		{
			return State.Running;
		}

		if (context.agent.remainingDistance < stoppingDistance)
		{
			return State.Success;
		}

		if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
		{
			return State.Failure;
		}

		return State.Running;
	}
}
