using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class CharacterAnimation : MonoBehaviour
	{
		private Animator m_animator;
		private AttackManager m_attackManager;
		private MovingComponent m_moving;

		static int SpeedMoveId = Animator.StringToHash("SpeedMove");
		static int AttackId = Animator.StringToHash("Attack");

		private Vector3 m_lastPosition;


		private void Awake()
		{
			m_animator = GetComponent<Animator>();
			m_attackManager = GetComponentInParent<AttackManager>();
			m_moving = GetComponentInParent<MovingComponent>();
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

		private void LateUpdate()
		{
			var velocity = Mathf.Clamp01(m_moving.velocity / m_moving.speed);
			m_animator.SetFloat(SpeedMoveId, velocity);
		}
	}
}
