using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
	public class AIPatrolState : StateMachineBehaviour
	{
		private IReadOnlyList<Vector3> m_points;
		private Enemy m_enemy;

		private Vector3 GetRandomPoint()
		{
			return m_points[Random.Range(0, m_points.Count)];
		}

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_enemy = animator.GetComponent<Enemy>();
			m_points = m_enemy.patrolPoints.GetPoints();
			m_enemy.Goto(GetRandomPoint());
		}

		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!m_enemy.isRunning)
			{
				animator.SetBool(AIStateId.IsPatrol, false);
			}
		}
	}
}