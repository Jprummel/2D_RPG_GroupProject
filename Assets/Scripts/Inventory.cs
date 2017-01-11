using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]private GameObject _inventoryPanel;
    [SerializeField]private GameObject _inventorySlotPanel;
    [SerializeField]private GameObject _inventoryBarPanel;
    [SerializeField]private GameObject _inventoryItemPrefab;

    private List<Item> _items = new List<Item>();
    private List<GameObject> _slots = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < _inventorySlotPanel.transform.childCount; i++)
        {
            _items.Add(new Item());
            _slots.Add(_inventorySlotPanel.transform.GetChild(i).gameObject);
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

    private void AddItem(int id)
    {
        Item itemToAdd = ItemDatabase.FetchItemByID(id);

        if(itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].ID == id)
                {
                    ItemData data = _slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].ID == -1)
                {
                    _items[i] = itemToAdd;
                    GameObject item = Instantiate(_inventoryItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                    item.GetComponent<ItemData>().item = itemToAdd;
                    item.transform.SetParent(_slots[i].transform, false);
                    item.transform.localPosition = Vector2.zero;
                    item.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    item.name = itemToAdd.Title;
                    break;
                }
            }
        }
    }

    private bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].ID == item.ID)
                return true;
        }
        return false;
    }
}
