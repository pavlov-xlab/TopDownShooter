using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
	NavMeshAgent m_Agent;
	RaycastHit m_HitInfo = new RaycastHit();

	void Start()
	{
		m_Agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		var mouse = UnityEngine.InputSystem.Mouse.current;
		var isMouseDown = mouse.leftButton.wasPressedThisFrame;
		if (isMouseDown)
		{
			var mousePosition = mouse.position.ReadValue();
			var ray = Camera.main.ScreenPointToRay(mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
				m_Agent.destination = m_HitInfo.point;
		}
	}
}
