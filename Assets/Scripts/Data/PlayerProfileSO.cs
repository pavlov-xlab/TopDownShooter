using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[CreateAssetMenu(fileName = "PlayerProfileSO", menuName = "PlayerProfileSO")]
	public class PlayerProfileSO : ScriptableObject
	{
		public AudioOptions audioOptions { get; private set; } = new AudioOptions();

		public int levelIndex { private set; get; }

		public void LeveUp()
		{
			levelIndex++;
		}

		public void LoadFromJson(string json)
		{
			if (!string.IsNullOrEmpty(json))
			{
				var data = JsonUtility.FromJson<PlayerProfileData>(json);
				if (data != null)
				{
					this.levelIndex = data.levelIndex;
					this.audioOptions = data.audioOptions;
				}
			}
		}

		public string ToJson()
		{
			PlayerProfileData data = new PlayerProfileData();
			data.levelIndex = this.levelIndex;
			data.audioOptions = this.audioOptions;

			return JsonUtility.ToJson(data);
		}
	}
}
