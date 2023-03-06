using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[System.Serializable]
	public class PlayerProfileData
	{
		public AudioOptions audioOptions = new();

		public int levelIndex;
	}


	[System.Serializable]
	public class AudioOptions
	{
		public float musicVolume;
		public float fxVolume;
	}
}
