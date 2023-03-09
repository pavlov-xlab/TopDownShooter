using UnityEngine;

namespace TopDownShooter
{
	public class UICoins : MonoBehaviour
	{
		[SerializeField] private TMPro.TextMeshProUGUI m_text;
		[SerializeField] private PlayerProfileSO m_playerProfileSO;

		private void OnEnable()
		{
			m_playerProfileSO.onCoinsChange += RefreshText;
			RefreshText(m_playerProfileSO.coins);
		}

		private void OnDisable()
		{
			m_playerProfileSO.onCoinsChange -= RefreshText;
		}

		private void RefreshText(int value)
		{
			m_text.text = value.ToString();
		}
	}
}
