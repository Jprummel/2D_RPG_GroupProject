using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateShop : MonoBehaviour {

    [SerializeField]private GameObject _panel;

	public void OpenShop()
    {
        _panel.SetActive(true);
    }

    public void CloseShop()
    {
        _panel.SetActive(false);
    }
}
