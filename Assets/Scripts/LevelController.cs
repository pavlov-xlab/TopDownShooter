using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class LevelController : MonoBehaviour
	{
		[SerializeField] private PlayerController m_playerController;
		[SerializeField] private Character m_playerPrefab;
		[SerializeField] private Transform m_spawnPoint;

		private void Start()
		{
			var player = SpawnPlayer();
			m_playerController.Init(player);
		}

		private Character SpawnPlayer()
		{
			return Instantiate(m_playerPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
		}
	}
}