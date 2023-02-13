using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class DestroySelf : ActionNode
{
	protected override void OnStart()
	{
		GameObject.Destroy(context.gameObject);
	}

	protected override void OnStop()
	{
	}

	protected override State OnUpdate()
	{
		return State.Running;
	}
}
