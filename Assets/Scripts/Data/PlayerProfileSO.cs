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
		private List<CharacterSaveData> m_characters = new();

		public CharacterSaveData GetCharacterSaveData(int index)
		{
			return m_characters[index];
		}

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
					m_characters = data.characters;

					Dictionary<string, EventData> dictionary = new();

					foreach (var item in dictionary)
					{
						item.Value.isComplete = data.completeEvents.IndexOf(item.Key) >= 0;
					}



				}
			}
		}

		public string ToJson()
		{
			PlayerProfileData data = new PlayerProfileData();
			data.levelIndex = this.levelIndex;
			data.audioOptions = this.audioOptions;
			data.characters = m_characters;

			Dictionary<string, EventData> dictionary = new();

			foreach (var item in dictionary)
			{
				data.completeEvents.Add(item.Key);
			}

			return JsonUtility.ToJson(data);
		}
	}

	public class EventData
	{
		public string key;
		public bool isComplete;

	}


}
