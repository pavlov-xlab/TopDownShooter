using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class Laser : MonoBehaviour
	{
		[SerializeField] private LineRenderer m_lineRenderer;

		private List<Vector3> m_points = new List<Vector3>();
		private void FixedUpdate()
		{
			m_points.Clear();
			
			Vector3 origin = transform.position;
			Vector3 direction = transform.forward;
			
			do
			{
				m_points.Add(origin);
				if (Physics.Raycast(origin, direction, out RaycastHit hit, 100f))
				{
					if (hit.transform.CompareTag("Glass"))
					{
						origin = hit.point;
						direction = Vector3.Reflect(direction, hit.normal);
					}
					else
					{
						if (hit.transform.TryGetComponent<DoorInteraction>(out var door))
						{
							door.Open();
						}
						
						m_points.Add(hit.point);
						break;
					}
				}
				else
				{
					break;
				}
			}
			while (m_points.Count < 10);

			if (m_points.Count > 1)
			{
				m_lineRenderer.positionCount = m_points.Count; 
				m_lineRenderer.SetPositions(m_points.ToArray());
			}
			else
			{
				m_lineRenderer.enabled = false;
			}
		}
	}
}