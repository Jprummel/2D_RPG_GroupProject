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

    private Transform _originalParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            _originalParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
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
        this.transform.SetParent(_originalParent);
        this.transform.localPosition = Vector2.zero;
    }
}
