namespace TheKiwiCoder
{
	[System.Serializable]
	public class InterruptSelector : Selector
	{
		protected override State OnUpdate()
		{
			int previous = current;
			current = 0;
			var status = base.OnUpdate();
			if (previous != current)
			{
				if (children[previous].state == State.Running)
				{
					children[previous].Abort();
				}
			}

			return status;
		}
	}
}