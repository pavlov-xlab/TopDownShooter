using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class CharacterAnimation : MonoBehaviour
	{
		private Animator m_animator;
		private AttackManager m_attackManager;

		static int SpeedMoveId = Animator.StringToHash("SpeedMove");
		static int AttackId = Animator.StringToHash("Attack");

		private Vector3 m_lastPosition;


		private void Awake()
		{
			m_animator = GetComponent<Animator>();
			m_attackManager = GetComponentInParent<AttackManager>();
		}

		private void OnEnable()
		{
			m_attackManager.onAttack.AddListener(OnAttackHandler);
		}

		private void OnDisable()
		{
			m_attackManager.onAttack.RemoveListener(OnAttackHandler);
		}

		private void OnAttackHandler()
		{
			m_animator.SetTrigger(AttackId);
		}

		private void Update()
		{
			Vector3 curPosition = transform.position;
			float distance = Vector3.Distance(curPosition, m_lastPosition);
			m_animator.SetFloat(SpeedMoveId, distance > 0 ? 1f : 0f);

			m_lastPosition = curPosition;
		}
	}
}
