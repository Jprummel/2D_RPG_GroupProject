using UnityEngine;
using System.Collections;

public class CreateNewCharacter : MonoBehaviour {

    private PlayerInformation   _playerInfo;
    private SaveLoadGame        _save;
    private ChoosePlayerGender  _gender;
    private ChoosePlayerName    _name;

	void Start () 
    {
        _playerInfo = GameObject.FindGameObjectWithTag(Tags.PLAYERINFO).GetComponent<PlayerInformation>();
        _save       = GameObject.FindGameObjectWithTag(Tags.SAVELOADOBJECT).GetComponent<SaveLoadGame>();
        _gender     = GetComponent<ChoosePlayerGender>();
        _name       = GetComponent<ChoosePlayerName>();
	}

    public void FinaliseCreation()
    {
        //Sets the entered name and gender for the player
        PlayerInformation.Name = _name.PlayerName;
        PlayerInformation.IsMale = _gender.IsMale;
        //Player starts at level 1 with 0 experience
        PlayerInformation.Level = 1;
        PlayerInformation.CurrentExperience = 0;
        PlayerInformation.RequiredExperience = 500;
        //Player starts with some gold
        PlayerInformation.Gold = 500;
        _save.SaveGame();

    }
}
