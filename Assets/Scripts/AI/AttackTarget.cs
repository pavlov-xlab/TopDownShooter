using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TopDownShooter.AI
{
	public class AttackTarget : ActionNode
	{
		private AttackManager m_attackManager;

		protected override void OnStart()
		{
			m_attackManager ??= context.gameObject.GetComponent<AttackManager>();

			if (m_attackManager)
			{
				m_attackManager.StartAttack();
			}
		}

		protected override void OnStop()
		{
			if (m_attackManager)
			{
				m_attackManager.StopAttack();
			}
		}

		protected override State OnUpdate()
		{
			return State.Running;
		}
	}
}
