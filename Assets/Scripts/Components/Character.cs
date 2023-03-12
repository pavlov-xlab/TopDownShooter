using UnityEngine;

namespace TopDownShooter
{
	public class Character : MonoBehaviour
	{
		[SerializeField] private CharacterData m_data;
		[HideInInspector] public HealthComponent health;
		[HideInInspector] public ManaComponent mana;
		[HideInInspector] public MovingComponent moving;
		[HideInInspector] public AttackManager attackManager;

		private void Start()
		{
			if (TryGetComponent(out health))
			{
				health.Init(m_data.health);
			}

			if (TryGetComponent(out mana))
			{
				mana.Init(m_data.mana, m_data.speedRestoreMana);
			}

			if (TryGetComponent(out moving))
			{
				moving.Init(m_data.speedMove);
			}

			if (TryGetComponent(out attackManager))
			{
				attackManager.Init(m_data.skills, m_data.baseDamage);
			}
		}
	}
}