using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField]private int _slotID;
    public int slotID
    {
        get { return _slotID; }
        set { _slotID = value; }
    }
    private Inventory _inv;

    void Start()
    {
        _inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (_inv.items[_slotID].ID == -1)
        {
            _inv.items[droppedItem.slotIndex] = new Item();
            _inv.items[_slotID] = droppedItem.item;
            droppedItem.slotIndex = _slotID;
        }
        else
        {
            var item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotIndex = droppedItem.slotIndex;
            item.transform.SetParent(_inv.slots[droppedItem.slotIndex].transform);
            item.transform.position = _inv.slots[droppedItem.slotIndex].transform.position;

            droppedItem.slotIndex = _slotID;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            _inv.items[droppedItem.slotIndex] = item.GetComponent<ItemData>().item;
            _inv.items[_slotID] = droppedItem.item;
        }
    }
}
