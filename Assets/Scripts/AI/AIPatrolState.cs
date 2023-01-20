using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{

	public class AIPatrolState : StateMachineBehaviour
	{
		private IReadOnlyList<Vector3> m_points;
		private NavMeshAgent m_agent;

		private Vector3 GetRandomPoint()
		{
			return m_points[Random.Range(0, m_points.Count)];
		}

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			var enemy = animator.GetComponent<Enemy>();
			m_agent = animator.GetComponent<NavMeshAgent>();
			m_points = enemy.patrolPoints.GetPoints();
			m_agent.destination = GetRandomPoint();
		}

		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (m_agent.remainingDistance <= m_agent.stoppingDistance)
			{
				m_agent.destination = GetRandomPoint();
			}
		}

		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{

		}
	}
}