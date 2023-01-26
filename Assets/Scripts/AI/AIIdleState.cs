using UnityEngine;

namespace TopDownShooter.AI
{
	public static class AIStateId
	{
		public static readonly int Idle = Animator.StringToHash("Idle");
		public static readonly int IsPatrol = Animator.StringToHash("IsPatrol");
		public static readonly int IsChasing = Animator.StringToHash("IsChasing");
	}
	
	
	public class AIIdleState : StateMachineBehaviour
	{
		[SerializeField] private float m_randomMin = 1f;
		[SerializeField] private float m_randomMax = 3f;
		private float m_timeStart = 0f;
		private float m_timeNextState = 0f;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_timeStart = Time.time;
			m_timeNextState = Random.Range(m_randomMin, m_randomMax);
		}

		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Time.time > m_timeStart + m_timeNextState)
			{
				animator.SetBool(AIStateId.IsPatrol, true);
			}
		}
	}
}