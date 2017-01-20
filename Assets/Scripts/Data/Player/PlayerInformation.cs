using UnityEngine;
using System.Collections;
[System.Serializable]
public class PlayerInformation : MonoBehaviour {

    void Awake()
    {
        //makes sure this object/script wont get destroyed
        DontDestroyOnLoad(this);
    }

    //General character Info
    public static string Name               { get; set; }
    public static bool IsMale               { get; set; }

    //Stats
    public static int Strength              { get; set; }
    public static int Dexterity             { get; set; }
    public static int Intellect             { get; set; }
    public static int Vitality              { get; set; }
    public static int Spirit                { get; set; }

    //Vitals
    public static int MaxHealth             { get; set; }
    public static int Health                { get; set; }
    public static int MaxMana               { get; set; }
    public static int Mana                  { get; set; }

    //Level related
    public static int Level                 { get; set; }
    public static int CurrentExperience     { get; set; }
    public static int RequiredExperience    { get; set; }
    public static int StatPoints            { get; set; }
    public static int Gold                  { get; set; }
}
