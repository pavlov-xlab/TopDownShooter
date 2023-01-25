using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{



	public class AIChasing : StateMachineBehaviour
	{
		private Animator m_animator;
		private Enemy m_enemy;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_animator = animator;
			m_enemy = m_animator.GetComponent<Enemy>();
			m_enemy.Goto(m_enemy.target.position);
		}

		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Time.frameCount % 3 == 0 && m_enemy.target)
			{
				m_enemy.Goto(m_enemy.target.position);
			}
		}
	}
}