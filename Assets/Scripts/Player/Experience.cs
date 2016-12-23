using UnityEngine;
using System.Collections;

public class Experience : MonoBehaviour {

    private int _experienceOverload;

    public void GainExperience(int experienceToGain)
    {
        //This function gives the player experience points after he kills a enemy or completes a quest
        PlayerInformation.Experience += experienceToGain;
        if (PlayerInformation.Experience >= PlayerInformation.RequiredExperience)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        //This function gives the player a level and 3 stat points
        if (PlayerInformation.Experience >= PlayerInformation.RequiredExperience)
        {
            _experienceOverload = PlayerInformation.RequiredExperience - PlayerInformation.Experience;
            PlayerInformation.Experience = _experienceOverload;
            PlayerInformation.Level++;
            PlayerInformation.StatPoints += 3;
            
        }
    }
}
