using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        AddItem(2);
    }

    private void AddItem(int id)
    {
        Item itemToAdd = ItemDatabase.FetchItemByID(id);
        for (int i = 0; i < _items.Count; i++)
        {
            if(_items[i].ID == -1)
            {
                _items[i] = itemToAdd;
                GameObject item = Instantiate(_inventoryItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                item.transform.SetParent(_slots[i].transform, false);
                item.transform.localPosition = Vector2.zero;
                item.name = itemToAdd.Title;
                break;
            }
        }
    }
}
