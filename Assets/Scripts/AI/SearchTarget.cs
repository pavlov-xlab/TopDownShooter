using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TopDownShooter.AI
{
	[System.Serializable]
	public class SearchTarget : ActionNode
	{
		public LayerMask mask;
		public float radius = 5;

		protected override void OnStart()
		{

		}

		protected override void OnStop()
		{

		}

		protected override State OnUpdate()
		{
			var target = Search(context.transform.position, radius, mask);

			blackboard.target = target;

			return target ? State.Success : State.Failure;
		}

		private Transform Search(Vector3 position, float radius, LayerMask mask)
		{
			var result = Physics.OverlapSphere(position, radius, mask, QueryTriggerInteraction.Ignore);
			if (result.Length > 0)
			{
				return result[0].transform;
			}

			return null;
		}

		public override void OnDrawGizmos()
		{
			if (context != null)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(context.transform.position, radius);
			}
		}
	}
}
