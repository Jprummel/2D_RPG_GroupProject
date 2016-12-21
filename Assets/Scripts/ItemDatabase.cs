using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    public static List<Item> database = new List<Item>();
    private JsonData _itemData;

    void Awake()
    {
        _itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
        Debug.Log("Item Data Loaded!");
    }

    public static Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;
    }

    private void ConstructItemDatabase()
    {
        for (int i = 0; i < _itemData.Count; i++)
        {
            database.Add(new Item(
                (int)   _itemData[i]["id"],
                        _itemData[i]["title"].ToString(),
                (int)   _itemData[i]["value"],
                (int)   _itemData[i]["stats"]["strength"],
                (int)   _itemData[i]["stats"]["dexterity"],
                (int)   _itemData[i]["stats"]["intellect"],
                (int)   _itemData[i]["stats"]["vitality"],
                (int)   _itemData[i]["stats"]["spirit"],
                (int)   _itemData[i]["stats"]["level"],
                        _itemData[i]["description"].ToString(),
                (bool)  _itemData[i]["stackable"],
                        _itemData[i]["rarity"].ToString(),
                        _itemData[i]["slug"].ToString()
                ));
        }
    }

}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intellect { get; set; }
    public int Vitality { get; set; }
    public int Spirit { get; set; }
    public int Level { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public string Rarity { get; set; }
    public string Slug { get; set; }

    public Item(int id, string title, int value, int strength, int dexterity, int intellect, int vitality, int spirit, int level, string description, bool stackable, string rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Strength = strength;
        this.Dexterity = dexterity;
        this.Intellect = intellect;
        this.Vitality = vitality;
        this.Spirit = spirit;
        this.Level = level;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
    }

    public Item()
    {
        this.ID = -1;
    }
}
