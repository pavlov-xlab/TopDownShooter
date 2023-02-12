using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace TopDownShooter
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private InputActionAsset m_inputAsset;
		[SerializeField] private CinemachineVirtualCamera m_virtualCamera;


		private Character m_character;
		private MovingComponent m_characterMoving;
		private AttackManager m_attackManager;

		private InputAction m_moveAction;
		private InputAction m_attackAction;
		private InputAction m_swapWeaponAction;

		private void Awake()
		{
			m_moveAction = m_inputAsset.FindAction("Move");
			m_attackAction = m_inputAsset.FindAction("Fire");
			m_swapWeaponAction = m_inputAsset.FindAction("SwapWeapon");
		}

		private void OnEnable()
		{
			m_inputAsset.FindActionMap("Player").Enable();
		}

		private void OnDisable()
		{
			m_inputAsset.FindActionMap("Player").Disable();
		}

		public void Init(Character character)
		{
			m_character = character;
			m_characterMoving = character.GetComponent<MovingComponent>();
			m_virtualCamera.Follow = character.transform;
			m_attackManager = character.GetComponent<AttackManager>();
		}

		private void Update()
		{
			if (m_character)
			{
				var move = m_moveAction.ReadValue<Vector2>();
				Vector3 offset = new(move.x, 0f, move.y);
				m_characterMoving.Move(offset);

				if (move.x != 0f || move.y != 0f)
				{
					m_characterMoving.Look(offset);
				}


				if (m_attackAction.WasPressedThisFrame())
				{
					m_attackManager.StartAttack();
				}

				if (m_attackAction.WasReleasedThisFrame())
				{
					m_attackManager.StopAttack();
				}

				if (m_swapWeaponAction.WasPerformedThisFrame())
				{
					m_attackManager.NextSkill();
				}
			}
		}
	}
}