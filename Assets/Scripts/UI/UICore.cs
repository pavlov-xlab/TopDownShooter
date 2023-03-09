using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
	public class UICore : MonoBehaviour
	{
		public static UICore current { private set; get; }

		private List<UIBasePanel> m_panels = new();
		[SerializeField] private string m_defaultPanel;

		private void Awake()
		{
			current = this;

			GetComponentsInChildren(true, m_panels);
		}

		private void Start()
		{
			Swap(m_defaultPanel);
		}

		public void HideAll()
		{
			m_panels.ForEach(x => x.Hide());
		}

		public void Show(string name)
		{
			var panel = m_panels.Find(x => x.name == name);
			if (panel)
			{
				panel.Show();
			}
		}

		public void Swap(string name)
		{
			var panel = m_panels.Find(x => x.name == name);
			if (panel)
			{
				HideAll();
				panel.Show();
			}
		}

		private void OnDestroy()
		{
			current = null;
		}

		public void LoadLevel()
		{
			SceneManager.LoadScene("SampleScene");
		}
	}
}
