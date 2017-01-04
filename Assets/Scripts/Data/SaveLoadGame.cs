using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public class SaveLoadGame : MonoBehaviour {

    private PlayerInformation _playerInfo;

    void Awake()
    {
        _playerInfo = GameObject.FindGameObjectWithTag(Tags.PLAYERINFO).GetComponent<PlayerInformation>();
    }

    public void SaveGame()
    {
        BinaryFormatter bf  = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "/SaveDataSlot.dat");

        SaveData saveData   = new SaveData();
        saveData.playerName = PlayerInformation.Name;
        saveData.isMale     = PlayerInformation.IsMale;
        saveData.strength   = PlayerInformation.Strength;
        saveData.dexterity  = PlayerInformation.Dexterity;
        saveData.intellect  = PlayerInformation.Intellect;
        saveData.vitality   = PlayerInformation.Vitality;
        saveData.spirit     = PlayerInformation.Spirit;
        saveData.maxHealth  = PlayerInformation.MaxHealth;
        saveData.health     = PlayerInformation.Health;
        saveData.maxMana    = PlayerInformation.MaxMana;
        saveData.mana       = PlayerInformation.Mana;
        saveData.level      = PlayerInformation.Level;
        //saveData.maxLevel = PlayerInformation.MaxLevel;
        saveData.experience = PlayerInformation.Experience;
        saveData.gold       = PlayerInformation.Gold;
        bf.Serialize(saveFile, saveData);
        saveFile.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveDataSlot.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/SaveDataSlot.dat",FileMode.Open);

            SaveData saveData               = (SaveData)bf.Deserialize(saveFile);
            PlayerInformation.Name          = saveData.playerName;
            PlayerInformation.IsMale        = saveData.isMale;
            PlayerInformation.Strength      = saveData.strength;
            PlayerInformation.Dexterity     = saveData.dexterity;
            PlayerInformation.Intellect     = saveData.intellect;
            PlayerInformation.Vitality      = saveData.vitality;
            PlayerInformation.Spirit        = saveData.spirit;
            PlayerInformation.MaxHealth     = saveData.maxHealth;
            PlayerInformation.Health        = saveData.health;
            PlayerInformation.MaxMana       = saveData.maxMana;
            PlayerInformation.Mana          = saveData.mana;
            PlayerInformation.Level         = saveData.level;
            //PlayerInformation.MaxLevel = saveData.maxLevel;
            PlayerInformation.Experience    = saveData.experience;
            PlayerInformation.Gold          = saveData.gold;
        }

        Debug.Log(PlayerInformation.Name);
        Debug.Log(PlayerInformation.Strength + "Str");
        Debug.Log(PlayerInformation.Dexterity + "Dex");
        Debug.Log(PlayerInformation.Intellect + "Int");
        Debug.Log(PlayerInformation.Vitality + "Vit");
        Debug.Log(PlayerInformation.Spirit + "SPR");
        Debug.Log(PlayerInformation.Level + "Level");
        Debug.Log(PlayerInformation.Gold + "Gold");
        PlayerInformation.StatPoints += 3;
        SceneManager.LoadScene("Test");

    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public bool isMale;
        public int strength;
        public int dexterity;
        public int intellect;
        public int vitality;
        public int spirit;
        public int maxHealth;
        public int health;
        public int maxMana;
        public int mana;
        public int level;
        public int maxLevel;
        public int experience;
        public int gold;
    }
}
