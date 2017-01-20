using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatAllocation : MonoBehaviour {

    //Buttons to add & remove stats
    [SerializeField]private List<GameObject> _addStatButtons = new List<GameObject>();
    [SerializeField]private List<GameObject> _removeStatButtons = new List<GameObject>();
    //Text showing available points
    [SerializeField]private Text _availablePointsText;
    [SerializeField]private List<Text> _statValueText = new List<Text>();
    private int[] _pointsToAllocate = new int[5];
    private int[] _baseStatPoints = new int[5];
    private int _usedPoints;
    private int _availablePoints;
	
    void Awake() 
    {
        PlayerStartingStats();
        AllocationStart();
	}
	
    void Update () 
    {
        ShowAvailablePoints();
        ShowButtons();
        RetrievePointsToAllocate();
        ShowStatValues();
	}

    void AllocationStart()
    {
        RetrieveBaseStatPoints();
        _availablePoints = 5;
    }

    public void ShowAvailablePoints()
    {
        //This functions is responsible for showing the player how many stat points he has left to allocate
        if (_availablePoints > 0)
        {
            _availablePointsText.text = "Available stat points : " + _availablePoints;
        }
        else
        {
            _availablePointsText.text = "";
        }
    }

    void PlayerStartingStats()
    {
        //this function sets all the players stats to 10 at the start of character creation
        PlayerInformation.Strength  = 10;
        PlayerInformation.Dexterity = 10;
        PlayerInformation.Intellect = 10;
        PlayerInformation.Vitality  = 10;
        PlayerInformation.Spirit    = 10;
    }

    public void ShowButtons()
    {        
        for (int i = 0; i < _pointsToAllocate.Length; i++)
        {
            //Only shows + buttons if there are available points to allocate
            if (_pointsToAllocate[i] >= _baseStatPoints[i] && _availablePoints > 0)
            {
                foreach (GameObject button in _addStatButtons)
                {
                    button.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject button in _addStatButtons)
                {
                    button.SetActive(false);
                }
            }

            //only show - buttons if there are points allocated and changes havent been confirmed yet
            if (_pointsToAllocate[i] > _baseStatPoints[i])
            {
                _removeStatButtons[i].SetActive(true);
            }
            else
            {
                _removeStatButtons[i].SetActive(false);
            }
        }
    }

    public void AddStatPoint(int statIndex)
    {
        //Adds a point to the selected stat when the + button is clicked (assign the proper number in the OnClick function of the button)
        switch (statIndex)
        {
            case 0:
                PlayerInformation.Strength += 1;
                break;
            case 1:
                PlayerInformation.Dexterity += 1;
                break;
            case 2:
                PlayerInformation.Intellect += 1;
                break;
            case 3:
                PlayerInformation.Vitality += 1;
                break;
            case 4:
                PlayerInformation.Spirit += 1;
                break;
        }
        _usedPoints += 1;
        _availablePoints--;
    }

    public void RemoveStatPoint(int statIndex)
    {
        //Removes a point to the selected stat when the + button is clicked (assign the proper number in the OnClick function of the button)
        switch (statIndex)
        {
            case 0:
                PlayerInformation.Strength -= 1;
                break;
            case 1:
                PlayerInformation.Dexterity -= 1;
                break;
            case 2:
                PlayerInformation.Intellect -= 1;
                break;
            case 3:
                PlayerInformation.Vitality -= 1;
                break;
            case 4:
                PlayerInformation.Spirit -= 1;
                break;
        }
        _usedPoints -= 1;
        _availablePoints++;
    }

    void RetrieveBaseStatPoints()
    {
        _baseStatPoints[0] = PlayerInformation.Strength;
        _baseStatPoints[1] = PlayerInformation.Dexterity;
        _baseStatPoints[2] = PlayerInformation.Intellect;
        _baseStatPoints[3] = PlayerInformation.Vitality;
        _baseStatPoints[4] = PlayerInformation.Spirit;
    }

    void RetrievePointsToAllocate()
    {
        _pointsToAllocate[0] = PlayerInformation.Strength;
        _pointsToAllocate[1] = PlayerInformation.Dexterity;
        _pointsToAllocate[2] = PlayerInformation.Intellect;
        _pointsToAllocate[3] = PlayerInformation.Vitality;
        _pointsToAllocate[4] = PlayerInformation.Spirit;
    }

    public void ShowStatValues()
    {
        //Shows the players stat values
        for (int i = 0; i < _statValueText.Count; i++)
        {
            switch (i)
            {
                case 0:
                    _statValueText[i].text = PlayerInformation.Strength.ToString();
                    break;
                case 1:
                    _statValueText[i].text = PlayerInformation.Dexterity.ToString();
                    break;
                case 2:
                    _statValueText[i].text = PlayerInformation.Intellect.ToString();
                    break;
                case 3:
                    _statValueText[i].text = PlayerInformation.Vitality.ToString();
                    break;
                case 4:
                    _statValueText[i].text = PlayerInformation.Spirit.ToString();
                    break;
            }
        }
    }
}
