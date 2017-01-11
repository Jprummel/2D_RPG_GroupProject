using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UIBar : MonoBehaviour, IEventSystemHandler
{
    [SerializeField]private Image _uiBar;
    [SerializeField]private string _barID;
	
    void OnEnable()
    {
        Resource.OnSendResource += UpdateBar;
    }

	void UpdateBar (string barID, float fillAmount, float maxFillAmount)
    {
        if(barID == _barID)
        {
            _uiBar.fillAmount = fillAmount / maxFillAmount;
            gameObject.SendMessage("SetHealthbarVisible");
        }
	}

    void OnDisable()
    {
        Resource.OnSendResource -= UpdateBar;
    }
}
