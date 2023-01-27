using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private PlayerController m_playerController;
		[SerializeField] private Character m_playerCharacterPrefab;
		[SerializeField] private Transform m_spawnPoint;

		private void Start()
		{
			var player = SpawnPlayer();
			m_playerController.Init(player);
		}

		private Character SpawnPlayer()
		{
			return Instantiate(m_playerCharacterPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
		}
	}

	public static class GameObjectExt
	{
		public static TypeComponent GetOrAddComponent<TypeComponent>(this GameObject go) where TypeComponent : class
		{
			if (go.TryGetComponent(typeof(TypeComponent), out var comp))
			{
				return comp as TypeComponent;
			}

			return go.AddComponent(typeof(TypeComponent)) as TypeComponent;
		}
	}
}