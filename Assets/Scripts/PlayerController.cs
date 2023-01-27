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
		private AttackManager m_attackManager;

		private Vector2 m_move;
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
			m_virtualCamera.Follow = character.transform;
			m_attackManager = character.GetComponent<AttackManager>();
		}

		public void OnMove(CallbackContext context)
		{
			m_move = context.ReadValue<Vector2>();
		}

		private void Update()
		{
			if (m_character)
			{
				m_move = m_moveAction.ReadValue<Vector2>();
				Vector3 offset = new Vector3(m_move.x, 0f, m_move.y);
				m_character.Move(offset);

				if (m_move.x != 0f || m_move.y != 0f)
				{
					m_character.SetLook(offset);
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
					m_attackManager.NextWeapon();
				}
			}
		}
	}
}