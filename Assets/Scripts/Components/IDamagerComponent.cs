using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public interface IDamagerComponent
	{
		void Attack(Transform target, float damage, float delay);
	}

	public interface IFlyingInitialization
	{
		void InitFlying(float flyingSpeed, float flyingDistance);
	}
}
