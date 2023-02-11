using System.Collections;
using System.Collections.Generic;
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
			context.transform.LookAt(blackboard.target.transform, Vector3.up);
			return State.Success;
		}
	}
}
