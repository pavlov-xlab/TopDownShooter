using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TopDownShooter.AI
{
	public class AttackTarget : ActionNode
	{
		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			if (context.attackManager.canAttack)
			{
				context.attackManager.Attack(blackboard.target);
			}
			return State.Running;
		}
	}
}
