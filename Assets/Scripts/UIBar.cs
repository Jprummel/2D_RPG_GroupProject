using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//put script on same object as Resource and HealthbarVisibility script
public class UIBar : MonoBehaviour, ISendHealth
{
    [SerializeField]private Image _uiBar;
    [SerializeField]private string _barID;

	public void UpdateBar (string barID, float fillAmount, float maxFillAmount)
    {
        if(barID == _barID)
        {
            _uiBar.fillAmount = fillAmount / maxFillAmount;
            gameObject.SendMessage("SetHealthbarVisible");
        }
	}
}
