using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShooter
{
	public class UIPlayerHUD : MonoBehaviour
	{
		[SerializeField] private Image m_healthImage;
		[SerializeField] private Image m_manaImage;

		public void Refresh(float healthPr, float manaPr)
		{
			m_healthImage.fillAmount = healthPr;
			m_manaImage.fillAmount = manaPr;
		}
	}
}
