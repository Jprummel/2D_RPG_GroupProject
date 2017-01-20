using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayName : MonoBehaviour
{

    [SerializeField] private Text _name;

	void Update () 
    {
	    DisplayCharacterName();
	}

    /// <summary>
    /// Shows the loaded characters name in the main menu
    /// </summary>
    void DisplayCharacterName()
    {
        _name.text = "Loaded Character : " + PlayerInformation.Name;
    }
}
