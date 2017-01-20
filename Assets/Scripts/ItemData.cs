using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Item _item;
    public Item item
    {
        get { return _item; }
        set { _item = value; }
    }
    private int _amount;
    public int amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    private int _slotIndex;
    public int slotIndex
    {
        get { return _slotIndex; }
        set { _slotIndex = value; }
    }

    private Inventory _inv;

    void Start()
    {
        _inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
            SetBlockRaycasts(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(_inv.slots[_slotIndex].transform);
        this.transform.localPosition = Vector2.zero;
        SetBlockRaycasts(true);
    }

    private void SetBlockRaycasts(bool value)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = value;
    }
}
