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
			// context.attackManager.StartAttack();
		}

		protected override void OnStop()
		{
			// context.attackManager.StopAttack();
		}

		protected override State OnUpdate()
		{
			return State.Running;
		}
	}
}
