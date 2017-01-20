using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]private GameObject _inventoryPanel;
    [SerializeField]private GameObject _inventorySlotPanel;
    [SerializeField]private GameObject _inventoryItemPrefab;

    private readonly List<Item> _items = new List<Item>();
    public List<Item> items
    {
        get { return _items; }
    }
    private readonly List<GameObject> _slots = new List<GameObject>();
    public List<GameObject> slots
    {
        get { return _slots; }
    }

    void Start()
    {
        for (var i = 0; i < _inventorySlotPanel.transform.childCount; i++)
        {
            _items.Add(new Item());
            _slots.Add(_inventorySlotPanel.transform.GetChild(i).gameObject);
            _slots[i].GetComponent<Slot>().slotID = i;
        }
        Debug.Log("Added all the slots!");
        AddItem(0);
        AddItem(1);
        AddItem(0);
        AddItem(1);
        AddItem(0);
        AddItem(1);
        AddItem(0);
    }

    public void AddItem(int id)
    {
        var itemToAdd = ItemDatabase.FetchItemByID(id);

        if(itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].ID != id) continue;
                var data = _slots[i].transform.GetChild(0).GetComponent<ItemData>();
                data.amount++;
                data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                break;
            }
        }
        else
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].ID != -1) continue;
                _items[i] = itemToAdd;
                var item = Instantiate(_inventoryItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                if (item != null)
                {
                    item.GetComponent<ItemData>().item = itemToAdd;
                    item.GetComponent<ItemData>().slotIndex = i;
                    item.transform.SetParent(_slots[i].transform, false);
                    item.transform.localPosition = Vector2.zero;
                    item.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    item.name = itemToAdd.Title;
                }
                break;
            }
        }
    }

    private bool CheckIfItemIsInInventory(Item item)
    {
        return _items.Any(t => t.ID == item.ID);
    }
}
