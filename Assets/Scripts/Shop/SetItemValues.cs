using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetItemValues : MonoBehaviour {

    private Image _image;
    private Text _text;
    [SerializeField]private int _itemId;

	// Use this for initialization
	void Start () {
        _image = GetComponentInChildren<Image>();
        _text = GetComponentInChildren<Text>();

        //itemdatabase.fetchitem(_itemId);
        //_image.sprite = item.image;
        //_text.text = item.value;
	}
}
