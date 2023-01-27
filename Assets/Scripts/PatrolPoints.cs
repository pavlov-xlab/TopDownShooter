using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{

	public class PatrolPoints : MonoBehaviour
	{
		private List<Vector3> m_points = new();

		private void Awake()
		{
			foreach (Transform child in transform)
			{
				m_points.Add(child.position);
			}
		}

		public IReadOnlyList<Vector3> GetPoints() => m_points;
	}
}