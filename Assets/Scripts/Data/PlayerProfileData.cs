using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	[System.Serializable]
	public class PlayerProfileData
	{
		public AudioOptions audioOptions = new AudioOptions();
		public Inventory inventory = new Inventory();

		public int levelIndex;
		public Vector3 playerPosition;

		public List<CharacterSaveData> characters = new();

		public List<string> completeEvents = new();
	}

	[System.Serializable]
	public class CharacterSaveData
	{
		public int level;
		public Inventory inventory = new();
	}



	[System.Serializable]
	public class AudioOptions
	{
		public float musicVolume;
		public float fxVolume;
	}

	[System.Serializable]
	public class Inventory
	{
		public int level;
		public List<InventoryItem> items = new();
	}

	[System.Serializable]
	public class InventoryItem
	{
		public int id;
		public int count;
	}


}
