using UnityEngine;

namespace TopDownShooter
{
	public static class GameObjectExtensions
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