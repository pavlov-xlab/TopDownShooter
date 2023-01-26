using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
	public class AIChasing : StateMachineBehaviour
	{
		private Enemy m_enemy;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_enemy = animator.GetComponent<Enemy>();
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