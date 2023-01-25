using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : StateMachineBehaviour
{
	private float m_timeStart = 0f;
	private float m_timeNextState = 0f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		m_timeStart = Time.time;
		m_timeNextState = Random.Range(2f, 5f);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (Time.time > m_timeStart + m_timeNextState)
		{
			animator.SetBool("isPatrol", true);
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

	}
}
