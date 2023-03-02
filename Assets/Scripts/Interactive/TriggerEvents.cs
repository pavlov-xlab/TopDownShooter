using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
	public class TriggerEvents : MonoBehaviour
	{
		[SerializeField] private UnityEvent<Collider> onTriggerEnter;
		[SerializeField] private UnityEvent<Collider> onTriggerExit;
		
		private void OnTriggerEnter(Collider other)
		{
			onTriggerEnter.Invoke(other);
		}

		public void OnTriggerExit(Collider other)
		{
			onTriggerExit.Invoke(other);
		}
	}
}