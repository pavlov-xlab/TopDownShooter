using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.States
{
	public abstract class GameStateBehavior : MonoBehaviour, IGameState
	{
		[SerializeField] private List<GameObject> m_views;
		protected StateMachine stateMachine { private set; get; }

		void IGameState.Init(StateMachine stateMachine)
		{
			this.stateMachine = stateMachine;
		}

		void IGameState.Enter()
		{
			gameObject.SetActive(true);
			OnEnter();
		}

		void IGameState.Exit()
		{
			gameObject.SetActive(false);
			OnExit();
		}

		public IReadOnlyList<GameObject> GetViews() => m_views;

		protected virtual void OnExit()
		{
			
		}

		protected virtual void OnEnter()
		{
			
		}
	}
}