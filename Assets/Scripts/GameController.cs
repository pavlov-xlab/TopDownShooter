using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class GameController : MonoBehaviour
	{
		public static GameController instance { get; private set; }

		public PlayerProfileSO playerProfile;

		private void Awake()
		{
			if (instance != null)
			{
				Debug.LogWarning("instance not null");
				Destroy(gameObject);
			}

			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		private void Start()
		{
			var json = PlayerPrefs.GetString("PlayerProfile");
			Debug.Log($">>> load {json}");
			playerProfile.LoadFromJson(json);

			// playerProfile.audioOptions.fxVolume;
			// playerProfile.audioOptions.musicVolume;
		}

		private void OnApplicationQuit()
		{
			playerProfile.audioOptions.fxVolume = 0.5f;
			var json = playerProfile.ToJson();
			Debug.Log($">>> save {json}");
			PlayerPrefs.SetString("PlayerProfile", json);
		}
	}
}
