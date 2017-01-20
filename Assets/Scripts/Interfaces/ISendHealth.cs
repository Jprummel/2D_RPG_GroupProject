using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface ISendHealth : IEventSystemHandler
{
    void UpdateBar(string barID, float fillAmount, float maxFillAmount);	
}
