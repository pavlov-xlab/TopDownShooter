using UnityEngine;

namespace TopDownShooter
{
	public class Character : MonoBehaviour
	{
		[SerializeField] private CharacterData m_data;

		private void Start()
		{
			if (TryGetComponent<HealthComponent>(out var health))
			{
				health.Init(m_data.health);
			}

			if (TryGetComponent<ManaComponent>(out var mana))
			{
				mana.Init(m_data.mana, m_data.speedRestoreMana);
			}

			if (TryGetComponent<MovingComponent>(out var moving))
			{
				moving.Init(m_data.speedMove);
			}
		}
	}
}