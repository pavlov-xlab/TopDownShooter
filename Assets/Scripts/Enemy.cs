using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private TargetSearcher m_searcher;
		public TargetSearcher searcher => m_searcher;
		private Transform m_target;
		private Animator m_animator;
		private NavMeshAgent m_agent;

		public Transform target => m_target;
		public PatrolPoints patrolPoints;

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
			m_target = null;
			m_animator.SetBool("isChasing", false);
		}

		private void OnTargetFind(GameObject go)
		{
			m_target = go.transform;
			m_animator.SetBool("isChasing", true);
		}
	}
}