using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpStatPointAllocation : MonoBehaviour {

    private int[] _pointsToAllocate = new int[5];       //Points to put in stats chosen by the player 
    private int[] _baseStatPoints = new int[5];       //Starting stat values for the chosen class
    private bool _didRunOnce;
    private int _usedPoints;
    private int _availablePoints;
    [SerializeField]private List<GameObject> _addStatButtons = new List<GameObject>();
    [SerializeField]private List<GameObject> _removeStatButtons = new List<GameObject>();
    [SerializeField]private List<Text> _statValueText = new List<Text>();
    [SerializeField]private GameObject _confirmButton;
    [SerializeField]private Text _availablePointsText;

    void Start()
    {
        if (!_didRunOnce)
        {
            RetrieveStatBaseStatPoints();
            _didRunOnce = true;
        }
        _availablePointsText = _availablePointsText.GetComponent<Text>();
    }

    void Update()
    {
        _availablePoints = PlayerInformation.StatPoints;

        ShowAvailableStatPoints();
        ShowButtons();
        RetrievePointsToAllocate();
        ShowPlayerStats();
    }

    void ShowPlayerStats()
    {
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

    void ShowAvailableStatPoints()
    {
        if (_availablePoints > 0)
        {
            _availablePointsText.text = "Available stat points : " + _availablePoints;
        }
        else
        {
            _availablePointsText.text = "";
        }
    }

    public void ShowButtons()
    {
        for (int i = 0; i < _pointsToAllocate.Length; i++)
        {
            
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

            if (_pointsToAllocate[i] > _baseStatPoints[i]) 
            {
                _removeStatButtons[i].SetActive(true);
            }
            else
            {
                _removeStatButtons[i].SetActive(false);
            }

            if (_usedPoints >= 1)
            {
                _confirmButton.SetActive(true);
            }
            else
            {
                _confirmButton.SetActive(false);
            }
        }
    }

    public void AddStatPoint(int statIndex)
    {
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
        PlayerInformation.StatPoints--;        
    }

    public void RemoveStatPoint(int statIndex)
    {
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
        PlayerInformation.StatPoints++;
    }

    public void ConfirmChanges()
    {
        //Confirms the changes made by the player
        _baseStatPoints[0] = PlayerInformation.Strength;
        _baseStatPoints[1] = PlayerInformation.Dexterity;
        _baseStatPoints[2] = PlayerInformation.Intellect;
        _baseStatPoints[3] = PlayerInformation.Vitality;
        _baseStatPoints[4] = PlayerInformation.Spirit;
        _usedPoints = 0;
    }

    public void CancelChanges()
    {
        PlayerInformation.Strength  = _baseStatPoints[0];
        PlayerInformation.Dexterity = _baseStatPoints[1];
        PlayerInformation.Intellect = _baseStatPoints[2];
        PlayerInformation.Vitality  = _baseStatPoints[3];
        PlayerInformation.Spirit    = _baseStatPoints[4];
        _usedPoints = 0;
    }

    void RetrieveStatBaseStatPoints()
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
}
