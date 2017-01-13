using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthbarVisibility : MonoBehaviour
{
    [SerializeField]private Image _healthbar;

	void Start ()
    {
        _healthbar.enabled = false;
	}
	
	void SetHealthbarVisible()
    {
        if (_healthbar.enabled == false)
        {
            _healthbar.enabled = true;
        }
    }
}