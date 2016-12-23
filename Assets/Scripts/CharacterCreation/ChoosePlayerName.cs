using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChoosePlayerName : MonoBehaviour {

    [SerializeField]private InputField _nameField;
    private string _playerName;
    //Getter and setter
    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }

    public void ChangeName()
    {
        _playerName = _nameField.text;
        Debug.Log(_playerName);
    }
}
