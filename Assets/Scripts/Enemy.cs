using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.AI;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private TargetSearcher m_searcher;
		public TargetSearcher searcher => m_searcher;
		private Animator m_animator;
		private NavMeshAgent m_agent;

		public Transform target { get; private set; }

		public PatrolPoints patrolPoints;

		public bool isRunning => m_agent.remainingDistance > m_agent.stoppingDistance;

		private void Awake()
		{
			m_animator = GetComponent<Animator>();
			m_agent = GetComponent<NavMeshAgent>();
		}

		public void Stop()
		{
			m_agent.isStopped = true;
		}

		public void Goto(in Vector3 point)
		{
			m_agent.isStopped = false;
			m_agent.SetDestination(point);
		}

		private void OnEnable()
		{
			m_searcher.onTargetFind += OnTargetFind;
			m_searcher.onTargetLost += OnTargetLost;
		}


		private void OnDisable()
		{
			m_searcher.onTargetFind -= OnTargetFind;
			m_searcher.onTargetLost -= OnTargetLost;
		}

		private void OnTargetLost(GameObject obj)
		{
			Stop();
			target = null;
			m_animator.SetBool(AIStateId.IsChasing, false);
		}

		private void OnTargetFind(GameObject go)
		{
			target = go.transform;
			m_animator.SetBool(AIStateId.IsChasing, true);
		}
	}
}